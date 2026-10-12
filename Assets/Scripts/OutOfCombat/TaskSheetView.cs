    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.XR;
using UnityEngine.UIElements;

public class TaskSheetView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;

    
    [SerializeField] private float spacing = 10f;
    [SerializeField] private TaskSheetInput taskSheetInput;
    private SpriteRenderer[] allRenderers;

    public TaskSheetData TaskSheetData {get; private set;}
    

    public void Awake(){
        taskSheetInput.SelectedEvent.AddListener(OnSelected);
        allRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void OnDestroy()
    {
    }
    


    public void Initialize(TaskSheetData taskSheetData)
        {
            TaskSheetData = taskSheetData;
            title.text = TaskSheetData.title;
            description.text = TaskSheetData.description;
            imageSR.sprite = TaskSheetData.image;
            
        }

        void OnSelected(TaskSheetInput input, TaskSheetData target){
            if (target != null)
            {
                PopTaskSheet(target);
                Debug.Log("touched");
            } else{
                Debug.Log("end drag");
                
            }
        }

        void PopTaskSheet(TaskSheetData taskSheetData)
    {
        
    }

    


    

}
