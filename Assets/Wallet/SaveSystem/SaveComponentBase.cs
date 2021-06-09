using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WalletModule.SaveSystem
{
    public enum SaveType
    {
        PlayerPrefs,FileJson,FileBinary
    }
    public abstract class SaveComponentBase : ISaveComponent
    {
        public string ID { get; }
        protected SaveComponentBase(string iD, IWallet wallet)
        {
            ID = iD;
            this.wallet = wallet;
        }
        public IWallet wallet { get; }
        public virtual string GetDataFromStorage()
        {
            return string.Empty;
        }
        protected ListOfCurrencySaveItem ListOfCurrencySaveItem()
        {
            ListOfCurrencySaveItem listOfCurrencySaveItem = new ListOfCurrencySaveItem();
            for (int index = 0; index < wallet.currencyContainer.currencies.Count; index++)
            {
                var item = wallet.currencyContainer.currencies.ElementAt(index);
                listOfCurrencySaveItem.list.Add(new CurrencySaveItem(item.Value.Id, item.Value.amount));
            }
            return listOfCurrencySaveItem;
        }
        public virtual string GetSerializedData()
        {
            return JsonUtility.ToJson(ListOfCurrencySaveItem());
        }
        public virtual ListOfCurrencySaveItem GetDeserializedData()
        {
            return JsonUtility.FromJson<ListOfCurrencySaveItem>(GetDataFromStorage()) ?? new ListOfCurrencySaveItem();
        }
        public virtual void Load()
        {
        }
        public virtual void Save()
        {
        }
    }
}