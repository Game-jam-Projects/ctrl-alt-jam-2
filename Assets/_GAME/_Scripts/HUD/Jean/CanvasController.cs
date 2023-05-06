using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Managers.Audio;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
   
    [Header("Paineis")]
    public GameObject painelMenuPrincipal;
    public GameObject painelButtonsOptions;
    public GameObject painelSound;
    public GameObject painelVideo;
    public GameObject painelControles;
    public GameObject painelLinguagem;

    public GameObject painelCurrent;
    public GameObject painelDisabled;

    public Toggle m_toogle_Screen; //trocar de local?
    public Toggle m_toogle_CamaraShake;

    [Header("Acesso ao botões Menu")]
    public Button buttonCurrent;
    public Button[] menu;
    public Slider slidercurrent;
    public Slider[] slider;

    [Header("Resolutions")]
    public TMP_Text resolutionLabel;


    public FixFullScreenResolution screenResolution;

   
    public static CanvasController Instance { get; private set; }

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

        painelCurrent = painelMenuPrincipal;
    }



    public void PauseGame()

    {
        bool pauseState = painelMenuPrincipal.activeSelf;

        //pauseState = !pauseState;
        //AudioManager.Instance.PlaySFX(AudioManager.Instance.uiSound1);
        switch (pauseState)
        {
            case true:
                Time.timeScale = 0;

                // ChangeGameState(gameState.NOGAMEPLAY);
                break;

            case false:
                Time.timeScale = 1;
                // ChangeGameState(gameState.GAMEPLAY);
                break;

        }

    }

    //public void SetCameraShake()
    //{
    //    if (m_toogle_CamaraShake.isOn == true)
    //    {
    //        GameManager.Instance.isOnShake = true;
    //        SaveLoad.Instance.SetSaveGameVideo();
    //    }
    //    else
    //    {
    //        GameManager.Instance.isOnShake = false;
    //        SaveLoad.Instance.SetSaveGameVideo();
    //    }
    //}


    public void SetFullScreen()
    {

        if (m_toogle_Screen.isOn == true)
        {

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

            Screen.SetResolution(screenResolution.resolutions[screenResolution.selectedResolution].horizontal,
             screenResolution.resolutions[screenResolution.selectedResolution].vertical, true);

            GameManagerJean.Instance.isFullScreen = Screen.fullScreen;

        }
        else if (m_toogle_Screen.isOn == false)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;

            Screen.SetResolution(screenResolution.windowedWidth, screenResolution.windowedHeight, false);
            GameManagerJean.Instance.isFullScreen = Screen.fullScreen;
        }
    }


    public void SetSelectedButton(Button button)
    {
        StartCoroutine(IEselectButton(button));
    }

    public void SetSelectedSlider(Slider slider)
    {
        StartCoroutine(IEselectSlider(slider));
    }

    public IEnumerator IEselectButton(Button button)
    {
        buttonCurrent = button;
        yield return new WaitForEndOfFrame();
        button.Select();
    }

    public IEnumerator IEselectSlider(Slider slider)
    {
        slidercurrent = slider;
        yield return new WaitForEndOfFrame();
        slider.Select();

    }

    //public void SetLanguage(string language)
    //{
    //    LeanLocalization.SetCurrentLanguageAll(language);
    //}

    public void SetRestartLevel(string nameScene)
    {

        GameManagerJean.Instance.LoadGameplay(nameScene);
    }

    public void BackToMenu(string nameScene)
    {

        GameManagerJean.Instance.prefabMenu = null;
        Time.timeScale = 1;
        GameManagerJean.Instance.LoadGameplay(nameScene);
    }

    public void RestartCurrent()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
