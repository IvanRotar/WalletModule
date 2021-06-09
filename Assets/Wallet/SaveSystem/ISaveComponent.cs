using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule.SaveSystem
{
    public interface ISaveComponent
    {
        string ID { get; }
        IWallet wallet { get; }
        string GetDataFromStorage();
        string GetSerializedData();
        ListOfCurrencySaveItem GetDeserializedData();
        void Save();
        void Load();
    }
}