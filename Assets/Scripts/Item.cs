using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Clothes,
}

public class Item : MonoBehaviour
{
    public ItemType itemType;
    public string itemName;
    public int cost;
    public Color itemSelectedColor;
}
