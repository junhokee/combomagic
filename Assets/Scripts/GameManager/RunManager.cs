using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance { get; private set; }

    public RunData CurrentRun { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartNewRun()
    {
        CurrentRun = new RunData();
    }

    public void SelectStage(TaskSheetData stage)
    {
        CurrentRun.currentStage = stage;
    }

    public void EndRun()
    {
        CurrentRun = null;
    }
}