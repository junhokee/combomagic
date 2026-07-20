using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviour
{
    public static ActionQueue Instance;
    private Queue<GameAction> queue = new Queue<GameAction>();
    private bool isProcessing;
    
    void Awake()
    {
        Instance = this;
    }

    public void Enqueue(GameAction action)
    {
        queue.Enqueue(action);
        if (!isProcessing)
        {
            StartCoroutine(ProcessQueue());
        }
    }

    IEnumerator ProcessQueue()
    {
        isProcessing = true;
        while(queue.Count > 0)
        {
            GameAction action = queue.Dequeue();
            yield return action.Execute();
        }
        isProcessing = false;
    }
}
