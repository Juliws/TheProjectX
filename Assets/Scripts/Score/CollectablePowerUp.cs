using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePowerUp : MonoBehaviour
{
    [SerializeField] private AudioClip sonidopunto;
    [SerializeField] private int cantidad;
    [SerializeField] private Score puntaje;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        particle.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            puntaje.sumarPuntos(cantidad);
            SoundsControl.Instance.Playsound(sonidopunto);
            pauseBtn.SetActive(false);
            Destroy(gameObject,0.4f);
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}


