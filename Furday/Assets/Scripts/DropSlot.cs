using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public ClothingType slotType;
    public Image equippedImage;
    void Start()
    {
        LoadEquippedItem();
    }

    void LoadEquippedItem()
    {
        string savedItemName = PlayerPrefs.GetString(slotType.ToString(), "");

        if (!string.IsNullOrEmpty(savedItemName))
        {
            // Find item in inventory
            ClothingItem item = FindItemByName(savedItemName);
            if (item != null)
            {
                equippedImage.sprite = item.itemSprite;
            }
        }
    }

    ClothingItem FindItemByName(string itemName)
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        return inventory.clothingItems.Find(item => item.itemName == itemName);
    }


    public void OnDrop(PointerEventData eventData)
    {
        DragItem draggedItem = eventData.pointerDrag?.GetComponent<DragItem>();

        if (draggedItem != null)
        {
            Debug.Log("Dropped item: " + draggedItem.clothingItem.itemName + " on " + slotType);

            if (draggedItem.clothingItem.clothingType == slotType)
            {
                // Get active character
                GameObject activeCharacter = CharacterManager.Instance.GetActiveCharacter();

                // Find the right slot on the active character
                DropSlot activeSlot = activeCharacter.GetComponentInChildren<DropSlot>();

                if (activeSlot != null)
                {
                    // If slot already has an item, return it to inventory
                    if (activeSlot.equippedImage.sprite != null)
                    {
                        Transform inventoryPanel = FindObjectOfType<InventoryManager>().inventoryPanel;
                        draggedItem.transform.SetParent(inventoryPanel);
                        draggedItem.rectTransform.anchoredPosition = Vector2.zero; // Reset position
                    }

                    // Equip new item on active character
                    activeSlot.equippedImage.sprite = draggedItem.clothingItem.itemSprite;
                    draggedItem.transform.SetParent(activeSlot.transform); // Move item to slot
                    draggedItem.transform.localPosition = Vector3.zero; // Snap to center
                    SaveEquippedItem(draggedItem.clothingItem);
                }
            }
            else
            {
                Debug.Log("Wrong slot! " + draggedItem.clothingItem.clothingType + " doesn't match " + slotType);
            }
        }
    }




    void SaveEquippedItem(ClothingItem item)
    {
        PlayerPrefs.SetString(slotType.ToString(), item.itemName);
        PlayerPrefs.Save();
    }
}
