using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public PlayerData playerData;
    public CharacterController2D player;

    public List<GameObject> weaponsObjs;
    public List<Item> clothesSlots;
    public List<Item> weaponsSlots;

    private Dictionary<string, Sprite> clothesSpritesDict;
    private Dictionary<string, Sprite> weaponsSpritesDict;

    private int currentClothesSlot;
    private int currentWeaponSlot;

    private Item selectedItem;
    private Item lastItemSelected;

    private void Awake()
    {
        UpdateClothesInventory();
        UpdateWeaponsInventory();
    }

    // Method for updating the clothes inventory
    public void UpdateClothesInventory()
    {
        if (clothesSpritesDict != null)
        {
            currentClothesSlot = 0;
            clothesSpritesDict.Clear();
        }

        // Create a dictionary from the player's clothes sprites
        clothesSpritesDict = playerData.clothesSprites.ToDictionary(sprite => sprite.name, sprite => sprite);

        // For each item in the player's clothes inventory...
        for (int i = 0; i < playerData.clothesInventory.Count; i++)
        {
            // ...if the clothes sprites dictionary contains the item...
            if (clothesSpritesDict.TryGetValue(playerData.clothesInventory[i], out Sprite sprite))
            {
                // ...get the Item component of the current clothes slot and its child Image component
                Item item = clothesSlots[currentClothesSlot].GetComponent<Item>();
                Transform child = item.transform.GetChild(2);
                Image image = child.GetComponent<Image>();

                // Set the item's name, mark it as already bought, and set its sprite
                item.itemName = sprite.name;
                item.isAlreadyBought = true;
                image.sprite = sprite;
                image.color = Color.white;
                currentClothesSlot++;
            }
        }
    }

    // Method for updating the weapons inventory
    public void UpdateWeaponsInventory()
    {
        if (weaponsSpritesDict != null)
        {
            currentWeaponSlot = 0;
            weaponsSpritesDict.Clear();
        }

        // Create a dictionary from the player's weapons sprites
        weaponsSpritesDict = playerData.WeaponsSprites.ToDictionary(sprite => sprite.name, sprite => sprite);

        // For each item in the player's weapons inventory...
        for (int i = 0; i < playerData.weaponsInventory.Count; i++)
        {
            // ...if the clothes sprites dictionary contains the item...
            if (weaponsSpritesDict.TryGetValue(playerData.weaponsInventory[i], out Sprite sprite))
            {
                // ...get the Item component of the current weapon slot and its child Image component
                Item item = weaponsSlots[currentWeaponSlot].GetComponent<Item>();
                Transform child = item.transform.GetChild(2);
                Image image = child.GetComponent<Image>();

                // Set the item's name, mark it as already bought, and set its sprite
                item.itemName = sprite.name;
                item.isAlreadyBought = true;
                image.sprite = sprite;
                image.color = Color.white;
                currentWeaponSlot++;
            }
        }
    }

    // Method for selecting an item in the shop
    public void SelectItem(Item selection)
    {
        if (!selection.isAlreadyBought)
        {
            return;
        }

        // If there was a previously selected item, reset its color to white
        if (lastItemSelected != null)
        {
            lastItemSelected.background.color = Color.white;
        }

        // Set the currently and last selected items to the given selection
        lastItemSelected = selectedItem = selection;

        // Change the color of the selected item and update the cost text
        selectedItem.background.color = selection.itemSelectedColor;

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
                    playerData.weaponActive = weapon.name;
                    weapon.SetActive(true);
                    break;
                }
            }
        }
    }
}
