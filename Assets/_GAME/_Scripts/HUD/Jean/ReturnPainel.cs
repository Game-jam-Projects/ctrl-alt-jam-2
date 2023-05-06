using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReturnPainel : MonoBehaviour
{
    public InputActionReference inputMove;
    public GameObject painelDisabled;
    public GameObject painelEnabled;
    public Button buttonDestined;
    private bool isPressed;

    

    private void OnEnable()
    {
       
        CanvasController.Instance.painelCurrent = painelEnabled;
        CanvasController.Instance.painelDisabled = painelDisabled;
       

        isPressed = false;
    }

    private void OnDisable()
    {
        CanvasController.Instance.buttonCurrent = buttonDestined;
        CanvasController.Instance.painelDisabled = null;
        CanvasController.Instance.painelCurrent = CanvasController.Instance.painelMenuPrincipal;
        isPressed = true;
    }

    private void Update()
    {
        if (!isPressed && inputMove.action.IsPressed())
        {
            print("teste2");
            isPressed = true;
            painelDisabled.SetActive(false);
            painelEnabled.SetActive(true);
            CanvasController.Instance.SetSelectedButton(buttonDestined);
            print("apertei");


       
        }

    }

   
}
