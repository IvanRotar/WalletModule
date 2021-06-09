using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule
{
    public interface ICurrencyFactory
    {
        ICurrencyContainer currencyContainer { get; }
        CurrencyBase CreateCurrency(CurrencyConfig currencyConfig, float balance = 0);
    }
}