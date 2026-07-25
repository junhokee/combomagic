using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.XR;

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

    [SerializeField] private CardInput cardInput;
    private SpriteRenderer[] allRenderers;
    private Color[] originalColors;

    public Card Card {get; private set;}
    public bool playable;
    

    public void Awake(){
        cardInput.DroppedEvent.AddListener(OnDropped);
        allRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[allRenderers.Length];

        for (int i = 0; i < allRenderers.Length; i++)
            originalColors[i] = allRenderers[i].color;
        ComboManager.Instance.ComboStateChangedEvent.AddListener(RefreshPlayability);
    }

    void OnDestroy()
    {
        ComboManager.Instance.ComboStateChangedEvent.RemoveListener(RefreshPlayability); // avoid leaks
    }



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

        void OnDropped(CardInput input, ICardTarget target){
            if (target != null && target.IsValidTarget(Card) && ComboManager.Instance.CanPlay(Card))
            {
                Card.Play(target);
                Debug.Log("invoked");
                input.PlayedEvent.Invoke(input);
            } else{
                Debug.Log("end drag");
                input.EndDragEvent.Invoke(input);
            }
        }

        public void ShowDisabled(bool darkened)
        {
            for (int i = 0; i < allRenderers.Length; i++)
            {
                if (darkened)
                {
                    Color c = originalColors[i];
                    c.r *= 0.5f;
                    c.g *= 0.5f;
                    c.b *= 0.5f;
                    // Leave alpha unchanged
                    allRenderers[i].color = c;
                }
                else
                {
                    allRenderers[i].color = originalColors[i];
                }
            }
        }

        public void RefreshPlayability()
        {
            bool canPlay = ComboManager.Instance.CanPlay(Card);
            playable = canPlay;
            ShowDisabled(!canPlay);
        }
    
    


    

}
