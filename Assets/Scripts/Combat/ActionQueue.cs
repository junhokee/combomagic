using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionQueue : MonoBehaviour
{
    public static ActionQueue Instance;
    private Queue<GameAction> queue = new Queue<GameAction>();
    private Queue<GameAction> preQueue = new Queue<GameAction>();
    public bool isProcessing {get; private set;}
    
    void Awake()
    {
        Instance = this;
    }

    public void EnqueueNextTurn(GameAction action)
    {
        preQueue.Enqueue(action);
    }

    public void TransferQueue()
    {
        while (preQueue.Count > 0)
        {
            queue.Enqueue(preQueue.Dequeue());
        }

        if (!isProcessing && queue.Count > 0)
            StartCoroutine(ProcessQueue());

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
