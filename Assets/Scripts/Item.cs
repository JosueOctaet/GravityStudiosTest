using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Weapon,
    Clothes,
}

public class Item : MonoBehaviour
{
    public PlayerData playerData;
    public ItemType itemType;

    public Image background;
    public string itemName;
    public int cost;

    public bool isInventory;
    public bool isAlreadyBought;

    public Color itemSelectedColor;
    public Color itemAlreadyBought;


    private void Start()
    {
        if (isInventory)
        {
            return;
        }

        switch (itemType)
        {
            case ItemType.Weapon:
                {
                    if (playerData.weaponsInventory.Contains(itemName))
                    {
                        ItemBought();
                    }
                }
                break;
            case ItemType.Clothes:
                {
                    if (playerData.clothesInventory.Contains(itemName))
                    {
                        ItemBought();
                    }
                }
                break;
            default:
                break;
        }
    }

    public void ItemBought()
    {
        background.color = itemAlreadyBought;
        isAlreadyBought = true;
    }
}
