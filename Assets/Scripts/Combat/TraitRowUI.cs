using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TraitRowUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text label;

    public void Setup(TraitInstance instance)
    {
        icon.sprite = instance.sprite;
        label.text = $"{instance.stacks}";
        label.ForceMeshUpdate();
    }
}