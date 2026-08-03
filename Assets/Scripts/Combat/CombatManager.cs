using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    [SerializeField] private Hand hand;
    [SerializeField] private Deck deck;
    [SerializeField] public List<Enemy> enemies;
    [SerializeField] private Player player;

    [SerializeField] private int cardsDrawnPerTurn = 5;

    public CombatState State { get; private set; }
    public UnityEvent<CombatState> StateChangedEvent;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(RunCombat());
    }

    IEnumerator RunCombat()
    {
        SetState(CombatState.StartCombat);
        yield return new WaitForSeconds(0.5f); // intro delay

        while (true)
        {
            yield return StartCoroutine(PlayerTurnRoutine());

            if (CheckCombatEnd()) yield break;

            yield return StartCoroutine(EnemyTurnRoutine());

            if (CheckCombatEnd()) yield break;
        }
    }

    IEnumerator PlayerTurnRoutine()
    {
        SetState(CombatState.PlayerTurnStart);
        ComboManager.Instance.ResetCombo();
        DrawCards(cardsDrawnPerTurn);

        yield return null;

        SetState(CombatState.PlayerTurn);

        // wait here until the player ends their turn (via End Turn button)
        waitingForEndTurn = true;
        yield return new WaitUntil(() => !waitingForEndTurn);

        SetState(CombatState.PlayerTurnEnd);
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

            // enemy.TakeTurn(player); // enemy decides + queues its own GameActions
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
            if (drawn == null) break; // empty deck, handle reshuffle elsewhere

            hand.AddCard(drawn); // assuming Hand.AddCard is adjusted to take Card and spawn its own CardView/CardInput
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
