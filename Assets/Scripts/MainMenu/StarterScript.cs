using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterScript : MonoBehaviour
{
    public StarterData starterData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStarterButtonPressed()
    {
        foreach(CardData c in starterData.cards)
        {
            RunManager.Instance.CurrentRun.deck.Add(new Card(c));
        }
        GameSceneManager.LoadStageSelection();
        
    }
}
