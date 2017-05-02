using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAudioController : MonoBehaviour {

    [SerializeField] AudioController audioController;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            audioController.FadeOutEnvironmentalAudio();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            audioController.FadeInEnvironmentalAudio();
        }
    }
}
