using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceParameter : MonoBehaviour
{
    FMOD.Studio.EventInstance Ambience;

    private void Start()
    {
        Ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Ambience");
        Ambience.start();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PLAYER")
            Ambience.setParameterByName("Ambience Fade", 1f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PLAYER")
            Ambience.setParameterByName("Ambience Fade", 0f);
    }*/

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            Ambience.setParameterByName("Ambience Fade", 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            Ambience.setParameterByName("Ambience Fade", 0f);
        }
    }*/ 

}