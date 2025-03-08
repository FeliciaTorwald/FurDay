using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ClothingItem clothingItem; // The item being dragged
    public RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;   

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // Remember where the item was before dragging
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(originalParent.root); // Move to top-level for visibility
    }


    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
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


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log(rectTransform.position.x);
        if (rectTransform.position.x <= 475)
        {
            var dropSlot = InventoryManager.instance.dropSlots[(int)clothingItem.clothingType];
            var equippedImage = dropSlot.equippedImage;

                // If the slot already has an equipped item, move it back to the inventory
                if (equippedImage.sprite != null)
                {
                    // Return the dragged item back to the inventory panel
                    Transform inventoryPanel = FindObjectOfType<InventoryManager>().inventoryPanel;
                    Transform[] children = dropSlot.GetComponentsInChildren<Transform>();
                    Debug.Log(transform.name);
                    foreach (Transform child in children)
                    {
                        if (child != dropSlot.transform)
                        {
                            child.SetParent(inventoryPanel); // Set the parent back to the inventory
                            child.localPosition = Vector3.zero; // Reset position to default
                            Debug.Log(child.name);
                        }
                    }
                }
                // Set the new sprite with centered pivot


                // Equip the new item
                equippedImage.sprite = clothingItem.itemSprite;
                transform.SetParent(dropSlot.transform); // Move the item to the equipped slot
                transform.localPosition = Vector3.zero; // Ensure it stays centered in the slot

                GetComponent<RectTransform>().anchoredPosition = clothingItem.anchoredPosition;



                // Set the sprite's native size
                SetNativeSize(this);

                //// Save the equipped item to PlayerPrefs
                //SaveEquippedItem(draggedItem.clothingItem);
            
        }
        // If dropped in a valid slot, stay there (DropSlot will handle it)
        if (transform.parent == originalParent.root)
        {
            // Return to inventory if dropped outside any valid slot
            transform.SetParent(FindObjectOfType<InventoryManager>().inventoryPanel);
            rectTransform.anchoredPosition = Vector2.zero; // Reset position
        }
    }


}
