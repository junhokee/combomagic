using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("Layout")]
    public float spacing = 1.5f;
    public float maxAngle = 10f;
    public float arcHeight = 0.3f;
    public CardView cardPrefab;
    [Header("cards")]
    //temp
    [SerializeField] private CardData ElectricPunch;
    [SerializeField] private CardData FirePunch;
    public CardInput selectedCard;
    private bool isCrossing = false;
    public List<Card> cards = new List<Card>();
    private List<CardInput> cardInputs = new List<CardInput>();
    private Dictionary<Card, CardView> cardViews = new Dictionary<Card, CardView>();
    

    


//temporary
    void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Card electricPunch = new Card(ElectricPunch);
                CardView view = Instantiate(cardPrefab);
                view.Initialize(electricPunch);
                CardInput input = view.gameObject.GetComponent<CardInput>();
                AddCardInput(input);
            }
             for (int i = 0; i < 5; i++)
            {
                Card electricPunch = new Card(FirePunch);
                CardView view = Instantiate(cardPrefab);
                view.Initialize(electricPunch);
                CardInput input = view.gameObject.GetComponent<CardInput>();
                AddCardInput(input);
            }
        }
    void Update()
    {
        if (selectedCard == null) return;
        if (isCrossing) return;
        for (int i = 0; i < cardInputs.Count; i++)
        {
            if (cardInputs[i] == selectedCard) continue;

            int selectedIndex = cardInputs.IndexOf(selectedCard);

            // dragged card moved to the RIGHT of a card that's currently ahead of it in the list
            if (selectedCard.transform.position.x > cardInputs[i].transform.position.x && selectedIndex < i)
            {
                Swap(selectedIndex, i);
                break;
            }

            // dragged card moved to the LEFT of a card that's currently behind it in the list
            if (selectedCard.transform.position.x < cardInputs[i].transform.position.x && selectedIndex > i)
            {
                Swap(selectedIndex, i);
                break;
            }
        }
    }

    public void Swap(int indexA, int indexB)
    {
        {
            isCrossing = true;

            Transform slotA = cardInputs[indexA].transform.parent;
            Transform slotB = cardInputs[indexB].transform.parent;

            cardInputs[indexB].transform.SetParent(slotA);
            cardInputs[indexB].transform.localPosition = Vector3.zero;
            cardInputs[indexB].transform.localRotation = Quaternion.identity;

            cardInputs[indexA].transform.SetParent(slotB);
            // don't reset selectedCard's local position — it's still being dragged, following the mouse

            // swap them in the list too, so order matches new parenting
            (cardInputs[indexA], cardInputs[indexB]) = (cardInputs[indexB], cardInputs[indexA]);

            isCrossing = false;

            ArrangeHand(); // recalculate sorting order for everyone (positions stay the same since slots didn't move)
        }
        
    }

    void OnEnable()
    {
        foreach (var card in cardInputs)
        {
            card.BeginDragEvent.AddListener(OnCardBeginDrag);
            card.EndDragEvent.AddListener(OnCardEndDrag);
            card.PointerEnterEvent.AddListener(OnCardEnter);
            card.PointerExitEvent.AddListener(OnCardExit);
            card.PlayedEvent.AddListener(OnCardPlayed);

                
        
            
        }
    }
    public Transform AddCardInput(CardInput card)
    {
        GameObject slotObj = new GameObject("Slot");
        slotObj.transform.SetParent(transform);
        cardInputs.Add(card);

        card.transform.SetParent(slotObj.transform);
        card.transform.localPosition = Vector3.zero;
        card.SetSlot(slotObj.transform);

        card.BeginDragEvent.AddListener(OnCardBeginDrag);
        card.EndDragEvent.AddListener(OnCardEndDrag);
        card.PointerEnterEvent.AddListener(OnCardEnter);
        card.PointerExitEvent.AddListener(OnCardExit);
        card.PlayedEvent.AddListener(OnCardPlayed);


        ArrangeHand();
        return slotObj.transform;
    }

    public Transform AddCard(Card card)
    {
        CardView cardObj = Instantiate(cardPrefab);
        CardInput cardInput = cardObj.GetComponent<CardInput>();
        cards.Add(card);
        cardObj.Initialize(card); // sets up visuals, traits, etc — your existing Initialize method
        cardViews.Add(card, cardObj);
        return AddCardInput(cardInput);
    }


    
    public void RemoveCard(CardInput card)
    {
        if(selectedCard == card)
        {
            selectedCard = null;
        }
        CardView view = card.GetComponent<CardView>();
        cards.Remove(view.Card);
        Transform slot = card.transform.parent;
        cardInputs.Remove(card);
        Destroy(slot.gameObject);

        ArrangeHand();
    }

     void ArrangeHand()
    {
        
        int count = cardInputs.Count;

        for (int i = 0; i < count; i++)
        {
            float t = count > 1 ? (float)i / (count - 1) - 0.5f : 0f;

            Vector3 pos = new Vector3(t * spacing * Mathf.Sqrt(count), -Mathf.Abs(t) * arcHeight, 0);
            float angle = -t * maxAngle;

            Transform slot = cardInputs[i].transform.parent;
            slot.localPosition = pos;
            slot.localRotation = Quaternion.Euler(0, 0, angle);
            cardInputs[i].SetBaseSortingOrder(count - i);

        }
    }

    void OnCardBeginDrag(CardInput card)
    {
        selectedCard = card;
    }

    void OnCardEndDrag(CardInput card)
    {
        selectedCard = null;
        SnapBackToSlot(card);
        card.SetSortingOrder(card.GetBaseSortingOrder());
        // snap back / reorder logic
    }
    void OnCardEnter(CardInput card)
    {
        selectedCard = card;
    }
    void OnCardExit(CardInput card)
    {
        selectedCard = null;
        SnapBackToSlot(card);
        card.SetSortingOrder(card.GetBaseSortingOrder());
    }

    void OnCardPlayed(CardInput card){
        Debug.Log("remove");
        RemoveCard(card);
    }

    void SnapBackToSlot(CardInput card)
    {
        card.transform.localPosition = Vector3.zero;
        card.transform.localRotation = Quaternion.identity;
    }
}
