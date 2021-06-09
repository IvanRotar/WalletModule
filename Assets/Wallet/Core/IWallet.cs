using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalletModule.SaveSystem;
using System;

namespace WalletModule
{
    public interface IWallet
    {
        ICurrencyContainer currencyContainer { get; set; }
        ICurrencyFactory currencyFactory { get; set; }
        ISaveComponent saveComponent { get; set; }
        List<CurrencyConfig> currencyConfigs { get; }
        void Init();
        Action OnInit { get; set; }
    }
}