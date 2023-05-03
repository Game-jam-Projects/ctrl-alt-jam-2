using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//namespace managersResolution
//{
    public class FixFullScreenResolution : MonoBehaviour
    {
        [Header("Maximum Resolution")]
       public int maxWidth = 1280;
       public int maxHeight = 720;
        
        [Header("Window Resolution")]
        public int windowedWidth = 640;
        public int windowedHeight = 360;

        bool fullscreenFixed = false;
        bool windowedFixed = false;
        bool wasFullScreen = false;

        public List<ResItem> resolutions = new List<ResItem>();

        [HideInInspector]
        public int selectedResolution;


        void Start()
        {
            Application.targetFrameRate = GameManagerJean.Instance.fpsGame;

          // Resolution[] resolutions = Screen.resolutions;
            //if(CanvasController.Instance.m_toogle_Screen != null)
            //{
            //    CanvasController.Instance.m_toogle_Screen.isOn = Screen.fullScreen;
            //}

            for( int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                selectedResolution = i;
               // UpdateRestLabel();
            }
        }
        // pick max resolution for full size
        //maxWidth = resolutions[resolutions.Length - 1].width;
        //maxHeight = resolutions[resolutions.Length - 1].width;
        maxWidth = Screen.width;
        maxHeight = Screen.height;
    }

        private void LateUpdate()
        {
            // if we are fullscreen now
            if (Screen.fullScreen == true)
            {
                wasFullScreen = true;
                windowedFixed = false;

                // and havent fixed resolution
                if (fullscreenFixed == false)
                {
                    fullscreenFixed = true;

                    // then fix it
                    Screen.SetResolution(maxWidth, maxHeight, true);
                   // CanvasController.Instance.m_toogle_Screen.isOn = true;
                }
                //            Debug.Log("---------------- full screen ---------------");
            }
            else // windowed
            {
                // we just came from fullscreen
                if (wasFullScreen == true)
                {
                    //                Debug.Log("********* came from full screen *****************");
                    wasFullScreen = false;

                    // if windowed resolution is still fullscreen size
                    if (windowedFixed == false)
                    {
                        windowedFixed = true;
                        Screen.SetResolution(windowedWidth, windowedHeight, false);
                       // CanvasController.Instance.m_toogle_Screen.isOn = false;
                        //                    Debug.Log("FixWindowed res " + windowedWidth + "," + windowedHeight);
                    }
                }
                else // we are still windowed
                {
                    // take current windowed size (for example user resized it)
                    windowedWidth = Screen.width;
                    windowedHeight = Screen.height;
                    //                Debug.Log("Take current window res = " + windowedWidth + "," + windowedHeight);
                }
                fullscreenFixed = false;

            }
        }


    #region UI funcion


    //public void UpdateRestLabel()
    //{
    //    CanvasController.Instance.resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " X " +
    //        resolutions[selectedResolution].vertical.ToString();
    //}
    //public void ApplyGraphics()
    //{
    //    // Screen.fullScreen = CanvasController.Instance.m_toogle_Scrren.isOn;
     
    //    Screen.SetResolution(resolutions[selectedResolution].horizontal,
    //        resolutions[selectedResolution].vertical, CanvasController.Instance.m_toogle_Screen.isOn);

    //    maxWidth = resolutions[selectedResolution].horizontal;
    //    maxHeight = resolutions[selectedResolution].vertical;

    //    //verificar se vamos manter a resolução de janela igual atual
    //    windowedWidth = resolutions[selectedResolution].horizontal;
    //    windowedHeight = resolutions[selectedResolution].vertical;

    //}

    //public void SetFullScreen()
    //{
      
    //    if (CanvasController.Instance.m_toogle_Screen.isOn== true)
    //    {
           
    //        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

    //       Screen.SetResolution(resolutions[selectedResolution].horizontal,
    //        resolutions[selectedResolution].vertical, true);

    //        GameManager.Instance.isFullScreen = Screen.fullScreen;

    //    }
    //    else if (CanvasController.Instance.m_toogle_Screen.isOn == false)
    //    {
    //        Screen.fullScreenMode = FullScreenMode.Windowed;
    
    //        Screen.SetResolution(windowedWidth, windowedHeight, false);
    //        GameManager.Instance.isFullScreen = Screen.fullScreen;
    //    }
    //}

    #endregion



}


//}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
