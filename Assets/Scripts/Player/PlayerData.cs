using System.Collections.Generic;
using UnityEngine;

// This script defines a PlayerData class that inherits from ScriptableObject
[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Game")]
    // The player's current gold
    public int currentGold;
    // A list of sprites for the player's clothes
    public List<Sprite> clothesSprites;
    // A list of sprites for the player's Weapons
    public List<Sprite> WeaponsSprites;

    // The player's inventory of weapons and clothes
    [Header("Inventories")]
    public List<string> weaponsInventory;
    public List<string> clothesInventory;

    // The active objects for the player's face, hood, shirt, pants, and weapon
    [Header("Active Objects")]
    public string faceActive = "Face";
    public string hoodActive = "Hood";
    public string shirtActive = "Shirt";
    public string pantsActive = "Pants";
    public string weaponActive;
}
