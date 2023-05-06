using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadValueVideo : MonoBehaviour
{

    private void Awake()
    {
        if (CanvasController.Instance.screenResolution ==null)
        {
            CanvasController.Instance.screenResolution = FindObjectOfType<FixFullScreenResolution>();
        }
    }

    private void OnEnable()
    {
        if (CanvasController.Instance.m_toogle_Screen != null)
        {
            CanvasController.Instance.m_toogle_Screen.isOn = Screen.fullScreen;

        }

    }
}
