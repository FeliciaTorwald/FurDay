
using UnityEngine;

[CreateAssetMenu(fileName = "NewClothingItem", menuName = "Clothing/Item")]
public class ClothingItem : ScriptableObject
{
    public string itemName;

    public Sprite itemSprite;  // Image of the clothing
    public GameObject itemPrefab; // Optional: Prefab for 3D/complex objects

    public ClothingType clothingType; // Category (Head, Torso, Legs, Feet)

    public bool usePrefab; // Toggle to decide if prefab should be used
}


public enum ClothingType
{
    Head,
    Torso,
    Legs,
    Feet
}

