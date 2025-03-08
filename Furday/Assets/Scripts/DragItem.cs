using UnityEngine;
using UnityEngine.EventSystems;

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


    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If dropped in a valid slot, stay there (DropSlot will handle it)
        if (transform.parent == originalParent.root)
        {
            // Return to inventory if dropped outside any valid slot
            transform.SetParent(FindObjectOfType<InventoryManager>().inventoryPanel);
            rectTransform.anchoredPosition = Vector2.zero; // Reset position
        }
    }


}
