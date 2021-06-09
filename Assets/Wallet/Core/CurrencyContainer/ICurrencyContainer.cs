using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalletModule.SaveSystem;

namespace WalletModule
{
    public interface ICurrencyContainer
    {
        Dictionary<string,ICurrency> currencies { get; set; }
        void Add(string id, ICurrency currency);
        void Remove(string id);
        ICurrency GetCurrency(string id);
    }
}