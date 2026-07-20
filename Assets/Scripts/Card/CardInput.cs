using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;


public class CardInput : MonoBehaviour
{
    [Header("UnityEvents")]
    public UnityEvent<CardInput> PointerEnterEvent;
    public UnityEvent<CardInput> PointerExitEvent;
    public UnityEvent<CardInput> BeginDragEvent;
    public UnityEvent<CardInput> EndDragEvent;
    public UnityEvent<CardInput> PlayedEvent;
    public UnityEvent<CardInput, ICardTarget> DroppedEvent;
    [Header("Card Dragging Stuff")]

    public static bool isAnyCardDragging = false;
    private Camera mainCamera;
    private float distanceFromCamera;
    private SortingGroup sortingGroup;
    private Vector3 hoverOffset = new Vector3(0, 0.3f, 0);
    private bool isDragging;
    private static CardInput currentlyHovered;

    private Transform mySlot;
    private float pointerDownTime;
    public int baseSortingOrder;

    public LayerMask targetLayer;
    
    void Awake() {
        mainCamera = Camera.main;
        sortingGroup = GetComponent<SortingGroup>();
    }
    public void SetSlot(Transform slot)
    {
        mySlot = slot;
    }

    void OnMouseDown()
    {
        distanceFromCamera = Vector3.Distance(mainCamera.transform.position, transform.position);
        isDragging = true;
        pointerDownTime = Time.time;
        isAnyCardDragging = true;
        sortingGroup.sortingOrder = 100;
        transform.rotation = Quaternion.identity;
        BeginDragEvent.Invoke(this);
    }

    void OnMouseDrag()
    {
        
        Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
        transform.position = mainCamera.ScreenToWorldPoint(screenPoint);
        sortingGroup.sortingOrder = 100;
        ICardTarget target = FindTargetUnderCard();
    }

    void OnMouseUp()
    {
        bool wasQuickClick = Time.time - pointerDownTime < 0.2f;
        isDragging = false;
        isAnyCardDragging = false;
        if (wasQuickClick)
        {
            // toggle selection logic here later
        }
        sortingGroup.sortingOrder = 0;
        ICardTarget target = FindTargetUnderCard();
        DroppedEvent.Invoke(this, target);

    }




    void OnMouseEnter()
    {
        if (isAnyCardDragging) return;
        if (currentlyHovered != null && currentlyHovered.GetBaseSortingOrder() > baseSortingOrder)
            return;

        PointerEnterEvent.Invoke(this);
        transform.position += hoverOffset;
        sortingGroup.sortingOrder = 100;
        currentlyHovered = this;
    }

    void OnMouseExit()
    {
        if (currentlyHovered == this)
            currentlyHovered = null;

        if (isAnyCardDragging) return;

        PointerExitEvent.Invoke(this);
    }

    public void SetBaseSortingOrder(int order)
    {
        baseSortingOrder = order;

        // don't override the visual order while actively dragging/hovering
        if (!isDragging)
            sortingGroup.sortingOrder = baseSortingOrder;
    }

    public int GetBaseSortingOrder()
    {
        return baseSortingOrder;
    }

    // Generic setter so Hand can push temporary overrides too if needed
    public void SetSortingOrder(int order)
    {
        sortingGroup.sortingOrder = order;
    }


    ICardTarget FindTargetUnderCard(){
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, targetLayer))
        {
            Debug.Log("i see it");
            return hit.collider.GetComponentInParent<ICardTarget>();
        }

        return null;
    }
    
}
