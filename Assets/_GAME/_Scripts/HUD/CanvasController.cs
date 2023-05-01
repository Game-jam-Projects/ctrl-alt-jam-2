using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CanvasController : MonoBehaviour
{

    [Header("Paineis")]
    public GameObject painelMenuPrincipal;
    public GameObject painelButtonsOptions;
    public GameObject painelSound;
    public GameObject painelVideo;
    public GameObject painelControles;

    public GameObject painelCurrent;
    public GameObject painelDisabled;


    [Header("Acesso ao botões Menu")]
    public Button buttonCurrent;
    public Button[] menu;
    public Slider slidercurrent;
    public Slider[] slider;

    [Header("Resolutions")]
    public TMP_Text resolutionLabel;
    public Toggle m_toogle_Screen;

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
                AudioListener.pause = true;

                // ChangeGameState(gameState.NOGAMEPLAY);
                break;

            case false:
                Time.timeScale = 1;
                AudioListener.pause = false;

                // ChangeGameState(gameState.GAMEPLAY);
                break;

        }

    }

    public void SetFullScreen()
    {

        if (m_toogle_Screen.isOn == true)
        {

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

            Screen.SetResolution(screenResolution.resolutions[screenResolution.selectedResolution].horizontal,
             screenResolution.resolutions[screenResolution.selectedResolution].vertical, true);

            GameManager.Instance.isFullScreen = Screen.fullScreen;

        }
        else if (m_toogle_Screen.isOn == false)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;

            Screen.SetResolution(screenResolution.windowedWidth, screenResolution.windowedHeight, false);
            GameManager.Instance.isFullScreen = Screen.fullScreen;
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


}