using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public PlayerData playerData;
    public CharacterController2D player;
    public List<Item> clothesSlots;

    private Dictionary<string, Sprite> clothesSpritesDict;
    private int currentClothesSlot;
    private Item selectedItem;
    private Item lastItemSelected;

    private void Awake()
    {
        UpdateClothesInventory();
    }

    public void UpdateClothesInventory()
    {
        if (clothesSpritesDict != null)
        {
            currentClothesSlot = 0;
            clothesSpritesDict.Clear();
        }

        clothesSpritesDict = playerData.clothesSprites.ToDictionary(sprite => sprite.name, sprite => sprite);

        for (int i = 0; i < playerData.clothesInventory.Count; i++)
        {
            if (clothesSpritesDict.TryGetValue(playerData.clothesInventory[i], out Sprite sprite))
            {
                Item item = clothesSlots[currentClothesSlot].GetComponent<Item>();
                Transform child = item.transform.GetChild(2);
                Image image = child.GetComponent<Image>();

                item.itemName = sprite.name;
                item.isAlreadyBought = true;
                image.sprite = sprite;
                image.color = Color.white;
                currentClothesSlot++;
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
}
