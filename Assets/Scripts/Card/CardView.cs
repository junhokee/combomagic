using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;
    [SerializeField] private Transform traitAnchor;
    [SerializeField] private List<TraitView> traitVisuals;

    
    [SerializeField] private float spacing = 10f;
    [SerializeField] private GameObject traitPrefab;

    public Card Card {get; private set;}
    public void Initialize(Card card)
        {
            Card = card;
            title.text = card.data.title;
            description.text = card.Description;
            imageSR.sprite = card.image;
            traitVisuals = new List<TraitView>();
            foreach (Traits t in card.traits) 
            { 
                TraitInstance traitInstance = new TraitInstance(t);
                AddTrait(traitInstance);
                

            }
        }

        void AddTrait(TraitInstance traitInstance)
        {
            GameObject traitObj = Instantiate(traitPrefab, traitAnchor);
            traitObj.transform.localPosition = Vector3.zero;


            TraitView traitView = traitObj.GetComponent<TraitView>();
            traitView.Initialize(traitInstance);

            traitVisuals.Add(traitView);
            ArrangeTraits();
        }
        void ArrangeTraits()
        {
            int count = traitVisuals.Count;

            for (int i = 0; i < count; i++)
            {
                float t = count > 1 ? (float)i / (count - 1) - 0.5f : 0f;
                Vector3 pos = new Vector3(t * spacing + count*0.2f, 0, 0);
                traitVisuals[i].transform.localPosition = pos; 
            }
        }
    
    


    

}
