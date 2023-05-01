using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
//Criação de arquivo Binario
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Managers.Audio;

public class SaveLoad :MonoBehaviour
{
    public static SaveLoad Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

        }
      //  SetLoadGameVideo();
    }

    public void SetSaveGameVideo()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");

        GameData data = new GameData();


        data.MasterVolumeSave = AudioManager.Instance.maxMasterVolume;
        data.MusicVolumeSave = AudioManager.Instance.maxMusicVolume;
        data.SfxVolumeSave = AudioManager.Instance.maxSfxVolume;

        data.fps = GameManager.Instance.fpsGame;

        bf.Serialize(file, data);
        file.Close();

    }

    public void SetLoadGameVideo()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);

            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            GameManager.Instance.fpsGame = data.fps;

            AudioManager.Instance.maxMasterVolume = data.MasterVolumeSave;
            AudioManager.Instance.maxMusicVolume = data.MusicVolumeSave;
            AudioManager.Instance.maxSfxVolume = data.SfxVolumeSave;

        }
    }



}

[Serializable]
class GameData
{
    //Variaveis para musica
    public float MasterVolumeSave;
    public float MusicVolumeSave;
    public float SfxVolumeSave;

    //Variavel Stage
    public bool isFinishedStage9;

    //UI
    public bool isCameraShakeSave;
    public int fps;
}
