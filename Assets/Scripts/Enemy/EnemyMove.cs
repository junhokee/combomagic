using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove: IActionSource
{
    public EnemyMoveData data;
    public string Title => data.title;
    public string Description => data.description;
    public Sprite image => data.image;
    public bool isAttack => data.isAttack;
    public List<Traits> traits;
    

    public EnemyMove(EnemyMoveData enemyMoveData)
    {
        this.data = enemyMoveData;
        traits = new List<Traits>();
        foreach (Traits t in enemyMoveData.baseTraits) 
        { 
            traits.Add(t);
        }
    }
    public EnemyMove(EnemyMoveData enemyMoveData, Enemy enemy)
    {
        this.data = enemyMoveData;
        traits = new List<Traits>();
        foreach (Traits t in enemyMoveData.baseTraits) 
        { 
            traits.Add(t);
        }
    }
    public void Execute(ICardTarget target, Enemy source)
    {
        foreach (Effect effect in data.effects)
        {
            GameAction action = effect.CreateAction(target, null);
            ActionQueue.Instance.Enqueue(action);
        }
    }



}
