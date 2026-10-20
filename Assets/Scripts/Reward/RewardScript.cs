using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public GameObject outline;
    public GameObject dathing;
    void Start()
    {
        outline.SetActive(false);
    }
    void OnMouseDown()
    {
        RunManager.Instance.CurrentRun.gold += RunManager.Instance.CurrentRun.currentStage.reward;
        Debug.Log("gold:" + RunManager.Instance.CurrentRun.gold);
        RunManager.Instance.SelectStage();
        // Destroy(dathing);
    }
    void OnMouseEnter()
    {
        if (this != null)
        {
            outline.SetActive(true);
        }
        
    }
    void OnMouseExit()
    {
        if (this != null)
        {
            outline.SetActive(false);
        }
    }
}
