using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonIconController : MonoBehaviour
{
    public string buttonName;
    public ButtonIconList buttonIconList;

    private Image buttonImage;
    public InputDevice inputDevice;
    public PlayerInput player;

    private void Awake()
    {

        buttonImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        inputDevice = player.GetDevice<InputDevice>();
        print(inputDevice.description.interfaceName);
        UpdateButtonIcon();
    }


    private void UpdateButtonIcon()
    {
        ButtonIconList.ButtonIcon buttonIcon = buttonIconList.buttonIcons.Find(x => x.buttonName == buttonName);

        if (buttonIcon == null)
        {
            Debug.LogError($"Button Icon not found for button: {buttonName}");
            return;
        }

        Sprite icon = null;

        switch (inputDevice.description.interfaceName)
        {
            case "RawInput":
                print("carregou aqui?");
                icon = buttonIcon.keyboardIcon;
                break;
            case "HID":
                icon = buttonIcon.ps4Icon;
                break;


            case "XInput":

                icon = buttonIcon.xboxIcon;
                break;

            default:
                Debug.LogWarning($"Interface name not recognized: {inputDevice.description.interfaceName}");
                break;
        }

        buttonImage.sprite = icon;
    }
}
