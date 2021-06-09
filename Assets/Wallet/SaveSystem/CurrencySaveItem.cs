using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[PreferBinarySerialization]
public class CurrencySaveItem
{
    public string id;
    public float amount;

    public CurrencySaveItem(string id, float amount)
    {
        this.id = id;
        this.amount = amount;
    }
}
