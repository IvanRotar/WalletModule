using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace WalletModule.SaveSystem
{
    [Serializable]
    public class ListOfCurrencySaveItem
    {
        public List<CurrencySaveItem> list = new List<CurrencySaveItem>();

        public CurrencySaveItem this[int key]
        {
            get { return list[key]; }
            set { list[key] = value; }
        }
    }
}