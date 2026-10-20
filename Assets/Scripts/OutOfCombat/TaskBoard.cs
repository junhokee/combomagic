using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TaskBoard : MonoBehaviour
{
    public TaskSheetView taskSheetPrefab;
    public List<TaskSheetData> taskSheetDatas;  

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            createTaskSheet(taskSheetDatas[i], new Vector3(-35.1f  + i * 30f, 11f, 50.2f));
            
        }
    }

    public TaskSheetView createTaskSheet(TaskSheetData data, Vector3 position)
    {
        
        
        TaskSheetView taskSheetView = Instantiate(taskSheetPrefab, position, Quaternion.identity);
        taskSheetView.Initialize(data);
        return taskSheetView;
    }
}
