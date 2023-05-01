using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Managers.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("Sources")]
        [SerializeField] public AudioSource musicSource;
        [SerializeField] public AudioSource sfxSource;
        [SerializeField] private AudioMixer audioMixer;

        [Header("Music")]


        [Header("Sound Effect Clips")]
  

        [Header("Enemies")]


        [Header("Weapons")]

        [Header("UI")]
        public AudioClip uiSound1;
        public AudioClip uiSound2;


        [Header("Blend Settings")]
        [SerializeField] private float blendValue = 0.1f;

        [Header("Settings")] //TODO: Save with PlayerPrefs
        public float maxMasterVolume = 1f;
        public float maxMusicVolume = 1f;
        public float maxSfxVolume = 1f;

        private void Start()
        {
            //Sistema que carrega o volume entre cenas

            if (SaveLoad.Instance != null) //colocado para n�o gerar erro em teste
            {
                SaveLoad.Instance.SetLoadGameVideo();
            }
            
        }

        public void ChangeMusic(AudioClip audioClip)
        {
            musicSource.clip = audioClip;
            musicSource.Play();
        }

        public void PlaySFX(AudioClip sfxClip) => sfxSource.PlayOneShot(sfxClip);

        public void UpdateMusicVolume(float value)
        {
            maxMusicVolume = value;
            musicSource.volume = value;
        }

        public void UpdateSfxVolume(float value)
        {
            maxSfxVolume = value;
            sfxSource.volume = value;
        }

        public void ChangeValueMusic(float volume)
        {
            audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
            maxMusicVolume = volume;
            SaveLoad.Instance.SetSaveGameVideo();

        }

        public void ChangeValueSFX(float volume)
        {
            audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
            maxSfxVolume = volume;
            SaveLoad.Instance.SetSaveGameVideo();
        }
        public void ChangeValueMaster(float volume)
        {
            audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
            maxMasterVolume = volume;
            SaveLoad.Instance.SetSaveGameVideo();
        }

      

        private IEnumerator BlendMusic(AudioClip newClip)
        {
            for (float i = musicSource.volume; i >= 0; i = -blendValue)
            {
                musicSource.volume = i;
                yield return new WaitForEndOfFrame();
            }

            musicSource.clip = newClip;
            musicSource.Play();

            for (float i = musicSource.volume; i <= maxMusicVolume; i = +blendValue)
            {
                musicSource.volume = i;
                yield return new WaitForEndOfFrame();
            }
        }

        public float GetMusicVolume() => maxMusicVolume;
        public float GetSfxVolume() => maxSfxVolume;
    }
}
