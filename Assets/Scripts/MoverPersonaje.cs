using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 15.0f;
    //public float velCorrer;
    public float x, y;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] private Collider colliderDePie;

    private Animator anim;

    [Header("Salto")]
    public float jumpForce = 15.0f;
    public bool enelSuelo;

    [Header("Agachado")]
    [SerializeField] private Transform controlTecho;
    [SerializeField] bool agachado = false;
    [SerializeField] bool estaAgachado = false;
    [SerializeField] private Collider colliderAgachado;
    

    private void Start()
    {
        //anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        agachado = GetComponent<bool>();
    }

    void Update()
    {
        MoverPlayer();
        //Correr();
        Jump();
    }

    private void MoverPlayer()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0);

        Agachado();
        //anim.SetFloat("VelX", x);
        //anim.SetFloat("VelY", y);
    }

    /*private void Correr()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            velocidadMovimiento = velCorrer;
            if (y > 0)
            {
                //anim.SetBool("correr", true);
                //    velCorrer = 7.0f;
            }
            else
            {
                //anim.SetBool("correr", false);
                velocidadMovimiento = 5.0f;
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        enelSuelo = true;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enelSuelo)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enelSuelo = false;
        }
    }

    public void Agachado()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            agachado = true;
            colliderAgachado.enabled = true;
            colliderDePie.enabled = false;
            Debug.Log("Agachado");
        }
        else
        {
            agachado = false;
            colliderAgachado.enabled = false;
            colliderDePie.enabled = true;
            Debug.Log("De Pie");
        }
    }
}
