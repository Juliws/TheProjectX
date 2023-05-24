using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private AudioClip sonidopunto;
    [SerializeField] private int cantidad;
    [SerializeField] private Score puntaje;
    [SerializeField] private ParticleSystem particle;
    //[SerializeField] private float timer;
    //[SerializeField] private float particleTime = 1;
    //[SerializeField] private GameObject collectable;
    //[SerializeField] private GameObject partic;


    private void Update()
    {
        //timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //timer += Time.deltaTime;
        if (other.tag == "Player")
        {
            puntaje.sumarPuntos(cantidad);
            SoundsControl.Instance.Playsound(sonidopunto);
            particle.Play();
            Destroy(gameObject,0.4f);
            //partic.SetActive(true);
            //collectable.SetActive(false);

            //TimePartycle();
        }
    }

    /*void TimePartycle() 
    {
        timer = 0;
        if (timer >= particleTime)
        {
            particle.Stop();
        }
    }*/
}


