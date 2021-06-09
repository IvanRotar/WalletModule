using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule
{
    [CreateAssetMenu(fileName = "CurrencyConfig.asset", menuName = "Wallet/CurrencyConfig")]
    public class CurrencyConfig : ScriptableObject
    {
        public string _id, _name;
        public Sprite _icon;
    }
}