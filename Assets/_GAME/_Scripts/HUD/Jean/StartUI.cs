using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class StartUI : MonoBehaviour
{
    public GameObject pressStart;
    public GameObject alienLogo;
    public GameObject began;
    private FixFullScreenResolution screenResolution;

    public InputActionReference input_start;

    private void Awake()
    {
        screenResolution = FindObjectOfType<FixFullScreenResolution>();
    }
    public void SetOnStart()
    {
        screenResolution = FindObjectOfType<FixFullScreenResolution>();
        pressStart.SetActive(false);
        began.SetActive(true);
        alienLogo.SetActive(false);


    }

    private void Update()
    {
        //if (InputSystem.GetDevice<Keyboard>() != null)
        //{
        //    if (input_start.action.IsPressed() && pressStart.activeSelf == true)
        //    {
        //        SetOnStart();
        //    }
        //}
        //if (InputSystem.GetDevice<Gamepad>() != null)
        //{
        //    if (input_start.action.IsPressed())
        //    {
        //        SetOnStart();
        //    }
        //}

        if (InputSystem.GetDevice<Keyboard>() != null)
        {
            if (InputSystem.GetDevice<Keyboard>().enterKey.wasPressedThisFrame && pressStart.activeSelf == true)
            {
                SetOnStart();
            }
        }

        if (InputSystem.GetDevice<Gamepad>() != null)
        {
            if (InputSystem.GetDevice<Gamepad>().startButton.wasPressedThisFrame && pressStart.activeSelf == true)
            {
                SetOnStart();
            }
        }



    }
}
