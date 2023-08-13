using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int gold;
    public List<Item> weaponsInventory;
    public List<Item> clothesInventory;
    public Item selectedItem;

    public void SelectItem(Item selection)
    {
        Image selectionImage = selection.transform.GetChild(1).GetComponent<Image>();
        selectionImage.color = Color.white;

        selectedItem = selection;
        selectionImage.color = selection.itemSelectedColor;
    }

    public void BuyItem()
    {
        if (gold >= selectedItem.cost)
        {
            gold -= selectedItem.cost;
            weaponsInventory.Add(selectedItem);

            if (selectedItem.itemType == ItemType.Weapon)
            {
                EquipWeapon(selectedItem);
            }
            else
            {
                EquipClothes(selectedItem);
            }
        }
        else
        {
            Debug.Log("Not enough gold to buy this item.");
        }
    }

    private void EquipWeapon(Item weapon)
    {
        // Find the next empty slot in the weapons inventory and equip the weapon
        for (int i = 0; i < weaponsInventory.Count; i++)
        {
            if (weaponsInventory[i] == null)
            {
                weaponsInventory[i] = weapon;
                break;
            }
        }
    }

    private void EquipClothes(Item clothes)
    {
        // Automatically save it in the clothes inventory
        clothesInventory.Add(clothes);
    }
}