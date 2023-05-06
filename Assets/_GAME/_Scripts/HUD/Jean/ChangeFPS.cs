using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ChangeFPS : MonoBehaviour, IMoveHandler
{
    [SerializeField]
    private TextMeshProUGUI fpsText;

    private void OnEnable()
    {
        fpsText.text = GameManagerJean.Instance.fpsGame.ToString();
    }

    public void OnMove(AxisEventData eventData)
    {
        switch (eventData.moveDir) 
        {

            case MoveDirection.Right:
                if(fpsText.text == "30")
                {

                    Application.targetFrameRate = 60;
                    GameManagerJean.Instance.fpsGame = 60;
                    fpsText.text = "60";
                    SaveLoad.Instance.SetSaveGameVideo();

                }
                else
                {
                    Application.targetFrameRate = 30;
                    GameManagerJean.Instance.fpsGame = 30;
                    fpsText.text = "30";
                    SaveLoad.Instance.SetSaveGameVideo();
                }
                

                break;


            case MoveDirection.Left:
                if (fpsText.text == "30")
                {
                    Application.targetFrameRate = 60;
                    GameManagerJean.Instance.fpsGame = 60;
                    fpsText.text = "60";
                    SaveLoad.Instance.SetSaveGameVideo();
                }
                else
                {
                    Application.targetFrameRate = 30;
                    GameManagerJean.Instance.fpsGame = 30;
                    fpsText.text = "30";
                    SaveLoad.Instance.SetSaveGameVideo();
                }
                break;

        }
    }
}
