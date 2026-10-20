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
        //THIS IS SUPER DUPER TEMPORARY
        StartNewRun();
    }

    public void StartNewRun()
    {
        CurrentRun = new RunData();
    }

    public void SelectStage(TaskSheetData stage)
    {
        CurrentRun.currentStage = stage;
    }

    public void GameOver()
    {
        GameSceneManager.LoadScene("GameOver");
    }
    public void CompleteEncounter()
    {
        CurrentRun.currentFloor++;
        GameSceneManager.LoadScene("RewardScene");
    }

    public void SelectStage()
    {
        GameSceneManager.LoadScene("OutOfCombat");
    }
    public void SelectStarter()
    {
        GameSceneManager.LoadScene("Starters");
    }

    public void EndRun()
    {
        CurrentRun = null;
    }
}