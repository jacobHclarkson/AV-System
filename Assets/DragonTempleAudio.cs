﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTempleAudio : MonoBehaviour {

    [SerializeField] AudioSource wind1;
    [SerializeField] AudioSource wind2;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            StartCoroutine(FadeOut(wind1, 3));
            StartCoroutine(FadeOut(wind2, 3));
        }
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 1;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = 1;
    }
}
