using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Game")]
    public int currentGold;
    public List<Sprite> clothesSprites;

    [Header("Inventories")]
    public List<string> weaponsInventory;
    public List<string> clothesInventory;

    [Header("Active Objects")]
    public string faceActive = "Face";
    public string hoodActive = "Hood";
    public string shirtActive = "Shirt";
    public string pantsActive = "Pants";
    public string weaponActive;
}
