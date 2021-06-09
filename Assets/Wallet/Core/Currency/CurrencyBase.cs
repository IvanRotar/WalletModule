using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule
{
    [System.Serializable]
    public class CurrencyBase : ICurrency
    {
        public string Id { get; }
        public float amount { get; set; }
        public virtual void Add(float value)
        {
            amount += value;
        }
        public virtual void Take(float value)
        {
            amount -= value;
        }
        public CurrencyBase(CurrencyConfig currencyConfig)
        {
            this.currencyConfig = currencyConfig;
            Id = currencyConfig._id;
        }
        public CurrencyBase(CurrencyConfig currencyConfig, float amount) : this(currencyConfig)
        {
            this.amount = amount;
        }
        protected CurrencyConfig currencyConfig { get; private set; }

    }
}