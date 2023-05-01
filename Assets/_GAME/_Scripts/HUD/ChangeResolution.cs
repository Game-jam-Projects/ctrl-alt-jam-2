using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeResolution : MonoBehaviour, IMoveHandler
{
    [SerializeField]
    FixFullScreenResolution screenResolution;


    private void Awake()
    {
        screenResolution = FindObjectOfType<FixFullScreenResolution>();
    }
    public void OnMove(AxisEventData eventData)
    {
        switch (eventData.moveDir)
        {
            case MoveDirection.Left:
                screenResolution.selectedResolution--;
                if(screenResolution.selectedResolution < 0)
                {
                    screenResolution.selectedResolution = 0;
                }
                screenResolution.UpdateRestLabel();
                screenResolution.ApplyGraphics();
              

                break;
            case MoveDirection.Right:
                screenResolution.selectedResolution++;
                if (screenResolution.selectedResolution > screenResolution.resolutions.Count -1)
                {
                    screenResolution.selectedResolution = screenResolution.resolutions.Count -1;
                }
                screenResolution.UpdateRestLabel();
                screenResolution.ApplyGraphics();

                break;
            case MoveDirection.None:
                break;
            default:
                break;






        }
    }

    
   
}
