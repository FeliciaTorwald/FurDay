using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public ClothingType slotType;  // Define which type of item this slot will hold (Head, Torso, Legs)
    public Image equippedImage;   // Image that represents the equipped item in this slot

    void Start()
    {
        LoadEquippedItem();
    }

    void LoadEquippedItem()
    {
        // Load previously equipped item from PlayerPrefs and apply it to the equippedImage
        string savedItemName = PlayerPrefs.GetString(slotType.ToString(), "");

        if (!string.IsNullOrEmpty(savedItemName))
        {
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
    private Sprite SetSpritePivot(Sprite originalSprite, Vector2 newPivot)
    {
        if (originalSprite == null) return null;

        return Sprite.Create(originalSprite.texture, originalSprite.rect, newPivot);
    }


    public void OnDrop(PointerEventData eventData)
    {
        DragItem draggedItem = eventData.pointerDrag?.GetComponent<DragItem>();

        if (draggedItem != null)
        {
            Debug.Log("Dropped item: " + draggedItem.clothingItem.itemName + " on " + slotType);

            // Check if the dragged item matches the slot type (Head, Torso, Legs, etc.)
            if (draggedItem.clothingItem.clothingType == slotType)
            {
                // If the slot already has an equipped item, move it back to the inventory
                if (equippedImage.sprite != null)
                {
                    // Return the dragged item back to the inventory panel
                    Transform inventoryPanel = FindObjectOfType<InventoryManager>().inventoryPanel;
                    Transform[] children = transform.GetComponentsInChildren<Transform>();
                    Debug.Log(transform.name);
                    foreach (Transform child in children)
                    {
                        if (child != transform)
                        {
                            child.SetParent(inventoryPanel); // Set the parent back to the inventory
                            child.localPosition = Vector3.zero; // Reset position to default
                            Debug.Log(child.name);
                        }
                    }
                }
                // Set the new sprite with centered pivot


                // Equip the new item
                equippedImage.sprite = draggedItem.clothingItem.itemSprite;
                draggedItem.transform.SetParent(transform); // Move the item to the equipped slot
                draggedItem.transform.localPosition = Vector3.zero; // Ensure it stays centered in the slot

                draggedItem.GetComponent<RectTransform>().anchoredPosition = draggedItem.clothingItem.anchoredPosition;


                // Set the sprite's native size
                SetNativeSize(draggedItem);

                // Save the equipped item to PlayerPrefs
                SaveEquippedItem(draggedItem.clothingItem);
            }
            else
            {
                Debug.Log("Wrong slot! " + draggedItem.clothingItem.clothingType + " doesn't match " + slotType);
            }
        }
    }

    void SetNativeSize(DragItem draggedItem)
    {
        // Get the sprite's native size and apply it to the RectTransform of the dragged item
        if (draggedItem.GetComponent<Image>() != null)
        {
            // Get the native size of the sprite (width and height) and adjust the RectTransform
            Sprite sprite = draggedItem.GetComponent<Image>().sprite;
            RectTransform rectTransform = draggedItem.GetComponent<RectTransform>();

            // Set the size of the RectTransform to match the native size of the sprite
            rectTransform.sizeDelta = new Vector2(sprite.rect.width, sprite.rect.height);
        }
    }

    void SaveEquippedItem(ClothingItem item)
    {
        // Save the equipped item name to PlayerPrefs so it can be loaded next time
        PlayerPrefs.SetString(slotType.ToString(), item.itemName);
        PlayerPrefs.Save();
    }
}
