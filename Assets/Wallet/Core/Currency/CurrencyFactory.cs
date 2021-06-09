using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule
{

    public class CurrencyFactoryBase : ICurrencyFactory
    {
        public CurrencyFactoryBase(ICurrencyContainer currencyContainer)
        {
            this.currencyContainer = currencyContainer;
        }
        public ICurrencyContainer currencyContainer { get; }

        public virtual CurrencyBase CreateCurrency(CurrencyConfig currencyConfig, float balance = 0)
        {
            var currency = new CurrencyBase(currencyConfig, balance);
            currencyContainer.Add(currencyConfig._id, currency);
            return currency;
        }
    }
}
