using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform inventoryPanel; // UI panel for inventory
    public GameObject inventoryItemPrefab; // Prefab for UI inventory item
    public List<ClothingItem> clothingItems;

    void Start()
    {
        PopulateInventory();
    }

    void PopulateInventory()
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);  // Clear old items
        }

        foreach (ClothingItem item in clothingItems)
        {
            Debug.Log("Adding item: " + item.itemName);  // Check which items are being added

            GameObject newItem = Instantiate(inventoryItemPrefab, inventoryPanel);


            // Assign the sprite dynamically
            newItem.GetComponent<UnityEngine.UI.Image>().sprite = item.itemSprite;

            // Assign the clothingItem to the DragItem component dynamically
            newItem.GetComponent<DragItem>().clothingItem = item;
        }
    }




}
