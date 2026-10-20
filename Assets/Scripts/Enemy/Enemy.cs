using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICardTarget
{
    [SerializeField] private Health health;

    public EnemyData Data { get; private set; }
    private EnemyMove currentMove;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public void Initialize(EnemyData data)
        {
            Data = data;
            health.SetMaxHealth(data.MaxHealth);
            spriteRenderer.sprite = data.image;
            // if (data.animatorController != null)
            //     animator.runtimeAnimatorController = data.animatorController;

            // if (spriteRenderer != null)
            //     spriteRenderer.sprite = data.portrait; // if enemies are simple sprites, not full animated models
        }
    public bool IsValidTarget(Card card)
    {
      if(!health.IsDead && card.isAttack)
        {
            
            return true;
        }  
        return false;
    } 

    
    public void ChooseNextMove()
    {
        EnemyMoveData chosen = Data.possibleMoves[Random.Range(0, Data.possibleMoves.Count)];
        currentMove = new EnemyMove(chosen, this);
    }


    public void TakeTurn()
    {
        ChooseNextMove();
        currentMove.Execute(Player.Instance, this);
    }

    public void HoverCard()
    {
        
    }
    public void DragCard()
    {
        
    }


    public void ReceiveCard(Card card)
    {
        
    }

    public Health getHealth()
    {
        return health;
    }

    public void ReceiveDamage(int amount)
    {
        health.TakeDamage(amount);
    }


}