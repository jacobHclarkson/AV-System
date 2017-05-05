using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolCollision : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip tableCollisionAudio;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Table_Top")
        {
            audioSource.PlayOneShot(tableCollisionAudio);
        }
        else
        {
            audioSource.Play();
        }
    }

}
