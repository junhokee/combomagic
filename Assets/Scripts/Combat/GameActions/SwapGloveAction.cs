using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGloveAction : GameAction
{
    private GameObject newPrefab;

    public SwapGloveAction(GameObject newPrefab)
    {
        this.newPrefab = newPrefab;
    }

    public override IEnumerator Execute()
    {
        yield return ViewModelManager.Instance.SwapViewmodel(newPrefab);
    }
}