using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsControl : MonoBehaviour
{
    public static SoundsControl Instance;
    private AudioSource audioSource;

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void Playsound(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
