using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCheck : MonoBehaviour
{
    private void OnEnable()
    {
        CanvasController.Instance.m_toogle_CamaraShake.isOn = GameManagerJean.Instance.isOnShake;
        GameManagerJean.Instance.isFullScreen = CanvasController.Instance.m_toogle_Screen.isOn;
    }
}
