using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeScript : MonoBehaviour {

    AudioSource audioSource;

    public AudioClip clip1;
    public AudioClip clip2;

    void Start()
    {
        audioSource.clip = clip1;

        audioSource.Play();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        { if (audioSource.clip = clip1)
            {
                audioSource.clip = clip2;

                audioSource.Play();
            }

        else
            {
                audioSource.clip = clip1;

                audioSource.Play();
            }
        }
    }

}
