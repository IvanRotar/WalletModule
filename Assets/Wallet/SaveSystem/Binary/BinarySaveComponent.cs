using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WalletModule.SaveSystem
{
    public class BinarySaveComponent : SaveComponentBase
    {
        public BinarySaveComponent(string iD, IWallet wallet) : base(iD, wallet)
        {
        }
        public override string GetDataFromStorage()
        {
            string result = string.Empty;
            if (File.Exists(SaveHelper.GetSaveFilePathFull()))
            {
                FileStream fileStream = new FileStream(SaveHelper.GetSaveFilePathFull(), FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                result = binaryFormatter.Deserialize(fileStream) as string;
            }
            return result;
        }
        public override ListOfCurrencySaveItem GetDeserializedData()
        {
            ListOfCurrencySaveItem listOfCurrencySaveItems = new ListOfCurrencySaveItem();
            if (File.Exists(SaveHelper.GetSaveFilePathFull()))
            {
                FileStream fileStream = new FileStream(SaveHelper.GetSaveFilePathFull(), FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                listOfCurrencySaveItems = binaryFormatter.Deserialize(fileStream) as ListOfCurrencySaveItem;
            }
            return listOfCurrencySaveItems ?? new ListOfCurrencySaveItem();
        }
        public override void Save()
        {
            base.Save();
            if (!Directory.Exists(SaveHelper.GetSaveFolderPath()))
                Directory.CreateDirectory(SaveHelper.GetSaveFolderPath());
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(SaveHelper.GetSaveFilePathFull(), FileMode.Create);
            binaryFormatter.Serialize(fileStream, ListOfCurrencySaveItem());
            fileStream.Close();
        }
    }
}