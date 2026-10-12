using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;


public class TaskSheetInput : MonoBehaviour
{
    [Header("UnityEvents")]
    public UnityEvent<TaskSheetInput> PointerEnterEvent;
    public UnityEvent<TaskSheetInput> PointerExitEvent;
    public UnityEvent<TaskSheetInput, TaskSheetData> SelectedEvent;
    [Header("Card Dragging Stuff")]

    public static bool isAnyCardDragging = false;
    private Camera mainCamera;
    private float distanceFromCamera;
    private Vector3 hoverOffset = new Vector3(0, 0.3f, 0);
    private static TaskSheetInput currentlyHovered;

    private Transform mySlot;
    [SerializeField] private GameObject outline;

    public LayerMask targetLayer;
    
    void Awake() {
        mainCamera = Camera.main;
        outline.SetActive(false);
    }
    public void SetSlot(Transform slot)
    {
        mySlot = slot;
    }

    void OnMouseDown()
    {   
        
        GameSceneManager.LoadScene("SampleScene");
        
    }





    void OnMouseEnter()
    {

        PointerEnterEvent.Invoke(this);
        currentlyHovered = this;
        outline.SetActive(true);
        Debug.Log("dragging");
    }

    void OnMouseExit()
    {
        if (currentlyHovered == this)
            currentlyHovered = null;
        outline.SetActive(false);

        PointerExitEvent.Invoke(this);
    }


        
}
