using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    [SerializeField] private Hand hand;
    [SerializeField] private Deck deck;
    [SerializeField] public List<EnemyData> enemyDatas;
    public List<Enemy> enemies;
    [SerializeField] private Player player;

    [SerializeField] private int cardsDrawnPerTurn = 5;
    public GameObject defaultHand;

    public CombatState State { get; private set; }
    public UnityEvent<CombatState> StateChangedEvent;
    private TaskSheetData data;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        data = RunManager.Instance.CurrentRun.currentStage;

        
        StartCoroutine(RunCombat());
        
    }

    IEnumerator RunCombat()
    {
        Debug.Log(EnemySpawner.Instance);

        for(int i = 0; i < data.enemies.Count; i ++)
        {
            EnemySpawner.Instance.SpawnEnemy(data.enemies[i], data.positions[i]);
        }   
        SetState(CombatState.StartCombat);
        ActionQueue.Instance.Enqueue(new SwapGloveAction(defaultHand));
        yield return new WaitForSeconds(0.5f); // intro delay

        while (true)
        {
            yield return StartCoroutine(PlayerTurnRoutine());

            if (CheckCombatEnd()) break;

            yield return StartCoroutine(EnemyTurnRoutine());

            if (CheckCombatEnd()) break;
        }
        yield return new WaitUntil(
            () => !ActionQueue.Instance.isProcessing
        );

        if (State == CombatState.Victory)
        {
            RunManager.Instance.CompleteEncounter();
        }
        else if (State == CombatState.Defeat)
        {
            RunManager.Instance.GameOver();
        }

    }

    IEnumerator PlayerTurnRoutine()
    {
        SetState(CombatState.PlayerTurnStart);
        foreach(Card c in hand.cards)
        {
            
        }
        
        DrawCards(cardsDrawnPerTurn);

        yield return null;

        SetState(CombatState.PlayerTurn);

        // wait here until the player ends their turn (via End Turn button)
        waitingForEndTurn = true;
        yield return new WaitUntil(() => !waitingForEndTurn);

        SetState(CombatState.PlayerTurnEnd);
        ComboManager.Instance.ResetCombo();
        yield return new WaitUntil(() => !ActionQueue.Instance.isProcessing); // let any lingering actions finish
    }

    IEnumerator EnemyTurnRoutine()
    {
        SetState(CombatState.EnemyTurnStart);
        yield return new WaitForSeconds(0.3f);

        SetState(CombatState.EnemyTurn);

        foreach (Enemy enemy in enemies)
        {
            if (enemy.getHealth().IsDead) continue;

            enemy.TakeTurn(); // enemy decides + queues its own GameActions
            yield return new WaitUntil(() => !ActionQueue.Instance.isProcessing);
        }

        SetState(CombatState.EnemyTurnEnd);
    }

    private bool waitingForEndTurn;

    public void OnEndTurnButtonPressed()
    {
        if (State != CombatState.PlayerTurn) return; // ignore clicks outside player turn
        waitingForEndTurn = false;
    }

    void DrawCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Card drawn = deck.DrawCard();
            if (drawn == null) break;

            hand.AddCard(drawn); 
        }
    }

    bool CheckCombatEnd()
    {
        if (player.getHealth().IsDead)
        {
            SetState(CombatState.Defeat);
            return true;
        }

        if (enemies.TrueForAll(e => e.getHealth().IsDead))
        {
            SetState(CombatState.Victory);
            return true;
        }

        return false;
    }

    void SetState(CombatState newState)
    {
        State = newState;
        StateChangedEvent.Invoke(newState);
        Debug.Log($"Combat state: {newState}");
    }

}
