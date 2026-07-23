using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitUI : MonoBehaviour
{
    public TraitManager traitmanager;
    [SerializeField] private GameObject traitRowPrefab;
    [SerializeField] private Transform container;
    private List<GameObject> spawnedRows = new List<GameObject>();
    void Awake()
    {
        traitmanager.TraitsChangedEvent.AddListener(Rebuild);
        Rebuild(new List<TraitInstance>());
    }

    void Rebuild(List<TraitInstance> traits)
    {
        foreach (var row in spawnedRows)
            Destroy(row);
        spawnedRows.Clear();
        foreach (var trait in traits)
        {
            GameObject rowObj = Instantiate(traitRowPrefab, container);
            rowObj.GetComponent<TraitRowUI>().Setup(trait);
            spawnedRows.Add(rowObj);
        }
    }

}
