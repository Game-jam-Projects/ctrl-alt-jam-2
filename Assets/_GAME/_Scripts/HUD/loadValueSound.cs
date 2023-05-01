using UnityEngine;
using Managers.Audio;
public class loadValueSound : MonoBehaviour
{
    private void OnEnable()
    {
        CanvasController.Instance.slider[0].onValueChanged.AddListener(AudioManager.Instance.ChangeValueMaster);
        CanvasController.Instance.slider[1].onValueChanged.AddListener(AudioManager.Instance.ChangeValueMusic);
        CanvasController.Instance.slider[2].onValueChanged.AddListener(AudioManager.Instance.ChangeValueSFX);

        CanvasController.Instance.slider[0].value = AudioManager.Instance.maxMasterVolume;
        CanvasController.Instance.slider[1].value = AudioManager.Instance.maxMusicVolume;
        CanvasController.Instance.slider[2].value = AudioManager.Instance.maxSfxVolume;
    }
}