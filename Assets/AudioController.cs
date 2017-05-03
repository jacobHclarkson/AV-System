using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    [SerializeField] AudioSource ocean;
    [SerializeField] AudioSource seagulls;
    [SerializeField] AudioSource forrest1;
    [SerializeField] AudioSource forrest2;
    //[SerializeField] AudioSource mountain1;
    //[SerializeField] AudioSource mountain2;

    AudioSource[] environmentalAudioSources;

    void Start()
    {
        environmentalAudioSources = new AudioSource[] { ocean, seagulls, forrest1, forrest2};
    }

    public void FadeOutEnvironmentalAudio()
    {
        for(int i =0; i<environmentalAudioSources.Length; i++)
        {
            StartCoroutine(FadeOut(environmentalAudioSources[i], 2));
        }
    }

    public void FadeInEnvironmentalAudio()
    {
        for(int i =0; i<environmentalAudioSources.Length; i++)
        {
            StartCoroutine(FadeIn(environmentalAudioSources[i], 2));
        }
    }

    IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
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
