using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalletModule.SaveSystem;

namespace WalletModule
{
    //Базовый класс кошелька
    public abstract class WalletBase : IWallet
    {
        public ICurrencyContainer currencyContainer { get; set; }
        public ICurrencyFactory currencyFactory { get; set; }
        public List<CurrencyConfig> currencyConfigs { get; set; }
        public ISaveComponent saveComponent { get; set; }
        public Action OnInit { get; set; }
        protected WalletBase(List<CurrencyConfig> currencyConfigs, SaveType saveType, string saveId)
        {
            this.currencyConfigs = currencyConfigs;
            switch (saveType)
            {
                case SaveType.FileBinary:
                    saveComponent = new BinarySaveComponent(saveId, this);
                    break;
                case SaveType.FileJson:
                    saveComponent = new FileJsonSaveComponent(saveId, this);
                    break;
                case SaveType.PlayerPrefs:
                    saveComponent = new PlayerPrefsSaveComponent(saveId, this);
                    break;
            }
        }
        public virtual void Init()
        {
            foreach (var currencyConfig in currencyConfigs)
            {
                currencyFactory.CreateCurrency(currencyConfig);
            }
            OnInit?.Invoke();
        }
        public float GetCurrencyAmount(string id)
        {
            return currencyContainer.GetCurrency(id).amount;
        }
        public void AddCurrencyAmount(string id, float value)
        {
            currencyContainer.GetCurrency(id).Add(value);
        }
        public void TakeCurrencyAmount(string id, float value)
        {
            currencyContainer.GetCurrency(id).Take(value);
        }
        public void Load()
        {
            saveComponent.Load();
            var loadData = saveComponent.GetDeserializedData();
            foreach (var item in loadData.list)
            {
                var currency = currencyContainer.GetCurrency(item.id);
                if (currency != null)
                    currency.amount = item.amount;
            }
        }
        public void Save()
        {
            saveComponent.Save();
        }
    }
}
