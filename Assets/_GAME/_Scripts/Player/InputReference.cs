using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

/// <summary>
/// Simula um botao, para evitar que seja trigado mais de uma vez no update
/// </summary>
public class InputButton
{
    public bool IsPressed;
}

/// <summary>
/// Usado pelo player
/// </summary>
public class InputReference : MonoBehaviour, PlayerControllerAction.IGameplayActions
{
    //quero pegar o valor, mas nao deixo ninguem de fora atualizar
    public Vector2 Movement { get; private set; } = Vector2.zero;
    public InputButton PauseButton { get; private set; } = new InputButton();
    public InputButton JumpButton { get; private set; } = new InputButton();

    public InputButton interacaoButton { get; private set; } = new InputButton();

    private PlayerControllerAction playerInputs;

    private void Start()
    {
        playerInputs = new PlayerControllerAction();

        playerInputs.gameplay.SetCallbacks(this);
        playerInputs.Enable();
    }

 

   

    private IEnumerator ResetButton(InputButton button)
    {
        yield return new WaitForEndOfFrame();

        if (button.IsPressed)
            button.IsPressed = false;
    }

    public void OnB(InputAction.CallbackContext context)
    {
        JumpButton.IsPressed = context.ReadValueAsButton();
        StartCoroutine(ResetButton(JumpButton));
    }

    public void OnY(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnA(InputAction.CallbackContext context)
    {
        interacaoButton.IsPressed = context.ReadValueAsButton();
    }

    public void OnR(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnR2(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnL2(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        PauseButton.IsPressed = context.ReadValueAsButton();
        StartCoroutine(ResetButton(PauseButton));
    }

    public void OnL(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        print("fazendo isso");
        var input = context.ReadValue<Vector2>();

        Movement = new Vector2(input.x, input.y).normalized;
    }
}
