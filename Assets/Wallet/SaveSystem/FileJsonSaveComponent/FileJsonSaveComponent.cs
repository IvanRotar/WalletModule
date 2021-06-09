using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WalletModule.SaveSystem
{
    public class FileJsonSaveComponent : SaveComponentBase
    {
        public FileJsonSaveComponent(string iD, IWallet wallet) : base(iD, wallet)
        {
        }
        public override string GetDataFromStorage()
        {
            string data = string.Empty;
            if (File.Exists(SaveHelper.GetSaveFilePathFull()))
            {
                data = File.ReadAllText(SaveHelper.GetSaveFilePathFull());
            }
            return data;
        }
        public override void Save()
        {
            base.Save();
            if (!Directory.Exists(SaveHelper.GetSaveFolderPath()))
                Directory.CreateDirectory(SaveHelper.GetSaveFolderPath());
            File.WriteAllText(SaveHelper.GetSaveFilePathFull(), GetSerializedData());
        }
    }
}