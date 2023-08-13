using UnityEngine;
using UnityEngine.UI;

// This script defines an ItemType enumeration
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
        // If the item is showing on the invetory UI
        if (isInventory)
        {
            // Ignore it
            return;
        }

        // Update the UI from the shop of all the items that the player already has in his inventory
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

    // Method for marking an item as bought
    public void ItemBought()
    {
        background.color = itemAlreadyBought;
        isAlreadyBought = true;
    }
}
