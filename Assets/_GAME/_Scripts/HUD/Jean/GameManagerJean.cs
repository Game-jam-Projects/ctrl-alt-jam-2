using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerJean : MonoBehaviour
{
    public static GameManagerJean Instance {get; private set;}



    [Header("Camera Shake")]
    public bool isOnShake = true;
    //public CheckShakeCam cameraShake;

    [Header("Screen")]
    public bool isFullScreen;

    [Header("System")]
    public int fpsGame;


    public GameObject prefabMenu;


    public void LoadGameplay(string nameScene)
    {

        SceneManager.LoadScene(nameScene);
    }


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
