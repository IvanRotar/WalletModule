using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalletModule
{
    public interface ICurrency
    {
        string Id { get; }
        float amount { get; set; }
        void Add(float value);
        void Take(float value);
    }
}