using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TaskBoard : MonoBehaviour
{
    public TaskSheetView taskSheetPrefab;
    public TaskSheetData taskSheetData;  

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            createTaskSheet(taskSheetData, new Vector3(-35.1f  + i * 30f, 11f, 45.2f));
            
        }
    }

    public TaskSheetView createTaskSheet(TaskSheetData data, Vector3 position)
    {
        
        
        TaskSheetView taskSheetView = Instantiate(taskSheetPrefab, position, Quaternion.identity);
        taskSheetView.Initialize(data);
        return taskSheetView;
    }
}
