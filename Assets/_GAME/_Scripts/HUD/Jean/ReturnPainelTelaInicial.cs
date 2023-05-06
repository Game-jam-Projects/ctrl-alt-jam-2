using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ReturnPainelTelaInicial : MonoBehaviour
{
    public InputActionReference inputMove;
    public GameObject painelDisabled;
    public GameObject painelEnabled;
    public Button buttonDestined;
    private bool isPressed;



    private void OnEnable()
    {
        isPressed = false;
    }

    private void OnDisable()
    {
      isPressed = true;
    }

    private void FixedUpdate()
    {
        if (!isPressed && inputMove.action.IsPressed())
        {
           
            isPressed = true;
            painelDisabled.SetActive(false);
            painelEnabled.SetActive(true);
            CanvasController.Instance.SetSelectedButton(buttonDestined);
           
        }

    }


}
