using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace WalletModule.SaveSystem
{
    public static class SaveHelper
    {
        public const string fileName = "WalletSaveData.json";
        public const string folderName = "Save";
        public static string GetSaveFilePathFull()
        {
            return Path.Combine(Application.streamingAssetsPath, folderName + "/" + fileName);
        }
        public static string GetSaveFolderPath()
        {
            return Path.Combine(Application.streamingAssetsPath, folderName);
        }
    }
}