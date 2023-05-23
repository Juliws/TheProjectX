using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private AudioClip sonidopunto;
    [SerializeField] private int cantidad;
    [SerializeField] private float timer;
    [SerializeField] private float particleTime = 1;
    [SerializeField] private Score puntaje;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject collectable;
    [SerializeField] private GameObject partic;


    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //timer += Time.deltaTime;
        if (other.tag == "Player")
        {
            puntaje.sumarPuntos(cantidad);
            SoundsControl.Instance.Playsound(sonidopunto);
            partic.SetActive(true);
            collectable.SetActive(false);
            particle.Play();
            TimePartycle();
        }
    }

    void TimePartycle() 
    {
        timer = 0;
        if (timer >= particleTime)
        {
            particle.Stop();
        }
    }
}


