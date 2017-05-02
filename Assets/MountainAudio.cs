using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainAudio : MonoBehaviour {

    [SerializeField] AudioSource wind1;
    [SerializeField] AudioSource wind2;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            StartCoroutine(FadeIn(wind1, 10));
            StartCoroutine(FadeIn(wind2, 10));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            StartCoroutine(FadeOut(wind1, 15));
            StartCoroutine(FadeOut(wind2, 15));
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

    IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        audioSource.volume = 0;
        audioSource.Play();
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        audioSource.volume = startVolume;
    }
}
