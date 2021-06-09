using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule.SaveSystem
{
    public class PlayerPrefsSaveComponent : SaveComponentBase
    {
        public PlayerPrefsSaveComponent(string iD, IWallet wallet) : base(iD, wallet)
        {
        }
        public override string GetDataFromStorage()
        {
            return PlayerPrefs.GetString(ID);
        }
        public override void Load()
        {
            base.Load();
        }

        public override void Save()
        {
            base.Save();
            PlayerPrefs.SetString(ID, GetSerializedData());
        }
    }
}