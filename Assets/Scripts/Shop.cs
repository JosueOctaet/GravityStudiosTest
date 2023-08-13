using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public CharacterController2D player;
    public PlayerData playerData;
    public Inventory inventory;
    public List<GameObject> weaponsObjs;

    public Item selectedItem;
    public Item lastItemSelected;

    public TextMeshProUGUI costText;

    // Method for selecting an item in the shop
    public void SelectItem(Item selection)
    {
        if (selection.isAlreadyBought)
        {
            return;
        }

        // Reset the player's clothes to their original sprites
        foreach (var item in playerData.clothesSprites)
        {
            if (item.name == "Face")
            {
                player.face.sprite = item;
            }
            else if (item.name == "Hood")
            {
                player.hood.sprite = item;
            }
            else if (item.name == "Shirt")
            {
                player.shirt.sprite = item;
            }
            else if (item.name == "Pants")
            {
                player.pants.sprite = item;
            }
        }

        // Reset the player's weapons objects
        foreach (var weapon in weaponsObjs)
        {
            weapon.SetActive(false);
        }

        // If there was a previously selected item, reset its color to white
        if (lastItemSelected != null && !lastItemSelected.isAlreadyBought)
        {
            lastItemSelected.background.color = Color.white;
        }

        // Set the currently and last selected items to the given selection
        lastItemSelected = selectedItem = selection;

        // Change the color of the selected item and update the cost text
        selectedItem.background.color = selection.itemSelectedColor;
        costText.text = $"{selection.itemName}: ${selection.cost}";

        if (selection.itemType == ItemType.Clothes)
        {
            // Change the player's clothes to match the selected item
            foreach (var item in playerData.clothesSprites)
            {
                if (item.name == selection.itemName)
                {
                    if (selection.itemName.Contains("Face"))
                    {
                        player.face.sprite = item;
                    }
                    else if (selection.itemName.Contains("Hood"))
                    {
                        player.hood.sprite = item;
                    }
                    else if (selection.itemName.Contains("Shirt"))
                    {
                        player.shirt.sprite = item;
                    }
                    else if (selection.itemName.Contains("Pants"))
                    {
                        player.pants.sprite = item;
                    }
                }
            }
        }
        else
        {
            // Change the player's weapon
            foreach (var weapon in weaponsObjs)
            {
                if (weapon.name == selection.itemName)
                {
                    weapon.SetActive(true);
                    break;
                }
            }
        }
    }

    // Method for buying the currently selected item in the shop
    public void BuyItem()
    {
        // Check if the player has enough gold to buy the selected item
        if (playerData.currentGold >= selectedItem.cost)
        {
            // Deduct the cost of the item from the player's gold
            playerData.currentGold -= selectedItem.cost;

            // Add the purchased item to the appropriate inventory
            if (selectedItem.itemType == ItemType.Weapon)
            {
                AddToWeaponInventory(selectedItem);
            }
            else
            {
                AddToClothesInventory(selectedItem);
            }
        }
        else
        {
            Debug.Log("Not enough gold to buy this item.");
        }
    }

    // Method for adding a weapon to the weapon inventory
    private void AddToWeaponInventory(Item weapon)
    {
        weapon.ItemBought();
        // Save the weapon in the weapons inventory
        playerData.weaponsInventory.Add(weapon.itemName);
        inventory.UpdateWeaponsInventory();
    }

    // Method for adding clothes to the clothes inventory
    private void AddToClothesInventory(Item clothes)
    {
        clothes.ItemBought();
        // Save the clothes in the clothes inventory
        playerData.clothesInventory.Add(clothes.itemName);
        inventory.UpdateClothesInventory();
    }
}
