using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private AudioClip sonidopunto;
    [SerializeField] private int cantidad;
    [SerializeField] private Score puntaje;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            puntaje.sumarPuntos(cantidad);
            SoundsControl.Instance.Playsound(sonidopunto);
            Destroy(gameObject);
        }
    }
}


