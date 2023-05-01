using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class StartUI : MonoBehaviour
{
    public GameObject pressStart;
    public GameObject began;

    public InputActionReference input_start;

    private void Awake()
    {
    }
    public void SetOnStart()
    {
        pressStart.SetActive(false);
        began.SetActive(true);

    }

    private void Update()
    {
        
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
