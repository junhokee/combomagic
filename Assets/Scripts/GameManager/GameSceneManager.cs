using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneManager
{
    private const string MAIN_MENU = "MainMenu";
    private const string STAGE_SELECT = "StageSelection";
    private const string BATTLE = "Battle";

    public static void LoadScene(String scene)
    {
        SceneManager.LoadScene(scene);
    }
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU);
    }
    public static void LoadStarters()
    {
        SceneManager.LoadScene("Starters");
    }

    public static void LoadStageSelection()
    {
        SceneManager.LoadScene(STAGE_SELECT);
    }

    public static void LoadBattle(TaskSheetData stage)
    {
        if (stage == null)
        {
            Debug.LogError("Cannot load battle: StageData is null!");
            return;
        }

        if (RunManager.Instance == null ||
            RunManager.Instance.CurrentRun == null)
        {
            Debug.LogError("Cannot load battle: No active run!");
            return;
        }

        RunManager.Instance.SelectStage(stage);

        SceneManager.LoadScene(BATTLE);
    }
}