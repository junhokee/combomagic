using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunData
{
    public TaskSheetData currentStage;

    public int currentFloor = 1;
    public int gold = 0;
    public int playerHealth = 100;

    public List<Card> deck = new();

}