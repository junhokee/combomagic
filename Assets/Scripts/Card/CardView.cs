using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;

    public Card Card {get; private set;}
    public void Initialize(Card card)
        {
            Card = card;
            title.text = card.data.title;
            description.text = card.Description;
            imageSR.sprite = card.image;
        }

}
