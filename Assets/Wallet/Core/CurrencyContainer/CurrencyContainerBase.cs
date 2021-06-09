using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalletModule.SaveSystem;

namespace WalletModule
{
    public class CurrencyContainerBase : ICurrencyContainer
    {
        public CurrencyContainerBase()
        {
            currencies = new Dictionary<string, ICurrency>();
        }

        public Dictionary<string, ICurrency> currencies { get; set; }
        public void Add(string id, ICurrency currency)
        {
            currencies[id] = currency;
        }
        public ICurrency GetCurrency(string id)
        {
            return currencies[id];
        }
        public void Remove(string id)
        {
            currencies.Remove(id);
        }
    }
}