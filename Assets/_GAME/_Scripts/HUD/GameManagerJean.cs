using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerJean : MonoBehaviour
{
    public static GameManagerJean Instance {get; private set;}

  
    [Header("Screen")]
    public bool isFullScreen;

    [Header("System")]
    public int fpsGame;




    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

        }
       

    }
}
