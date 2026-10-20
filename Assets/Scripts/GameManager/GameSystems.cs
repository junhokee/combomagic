using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class GameSystems : MonoBehaviour
{
    private static GameSystems instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}