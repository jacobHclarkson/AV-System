using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAudioController : MonoBehaviour {

    [SerializeField] AudioController audioController;
    [SerializeField] UnityStandardAssets.Characters.FirstPerson.FirstPersonController character;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            audioController.FadeOutEnvironmentalAudio();
            character.outside = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            audioController.FadeInEnvironmentalAudio();
            character.outside = true;
        }
    }
}
