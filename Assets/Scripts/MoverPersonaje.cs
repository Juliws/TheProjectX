using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 10.0f;
    public float x, y;
    public Animator anim;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] private Collider colliderDePie;
    [SerializeField] public Transform giroCharacterChild;
    //[SerializeField] public Transform giroCharacterTeen;
    [SerializeField] private Quaternion giroAtras;
    [SerializeField] private Quaternion giroFrente;

    [Header("Salto")]
    public float jumpForce = 15.0f;
    public bool enelSuelo;

    [Header("Agachado")]
    [SerializeField] private Transform controlTecho;
    [SerializeField] private Collider colliderAgachado;
    public bool agachado = false;
    public bool estaAgachado = false;

    [Header("PowerUpsCheck")]
    public bool powerUpJump;
    public bool powerUpCrouch;
    public bool powerUpAttack;

    private void Start()
    {
        anim= GetComponentInChildren<Animator>();
        playerRb = GetComponent<Rigidbody>();
        agachado = GetComponent<GameObject>();
    }

    void Update()
    {
        MoverPlayer();
        //Correr();
        Jump(powerUpJump);
        Ataque(powerUpAttack);
    }

    private void MoverPlayer()
    {
        x = Input.GetAxisRaw("Horizontal"); //Obtiene el input para moverse horizontalmente
        //y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0); //Recibe el input para mover el personaje de manera horizontal

        anim.SetFloat("VelX", x);
        Agachado(powerUpCrouch);
        
        //Giro del personaje izquierda
        if (x < 0)
        {
            giroCharacterChild.transform.rotation = giroAtras;
            //giroCharacterTeen.transform.rotation = giroAtras;
        }
        //Giro del personaje derecha
        else if (x > 0)
        {
            giroCharacterChild.transform.rotation = giroFrente;
            //giroCharacterTeen.transform.rotation = giroAtras;
        }

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
        
        if (collision.gameObject.CompareTag("PwrupJump"))
        {
            powerUpJump = true;
            Debug.Log("Puedes Saltar");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PwrupCrouch"))
        {
            powerUpCrouch = true;
            Debug.Log("Puedes Agacharte");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PwrupAttack"))
        {
           powerUpAttack = true;
            Debug.Log("Puedes Atacar");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    public void Jump(bool jump)
    {
        if (Input.GetKeyDown(KeyCode.Space) && enelSuelo)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enelSuelo = false;
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }

    public void Agachado(bool crouch)
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            agachado = true;
            colliderAgachado.enabled = true;
            anim.SetBool("Crouch", true);
            colliderDePie.enabled = false;
            Debug.Log("Agachado");
        }
        else
        {
            agachado = false;
            colliderAgachado.enabled = false;
            colliderDePie.enabled = true;
            anim.SetBool("Crouch", false);
            Debug.Log("De Pie");
        }
    }

    public void Ataque(bool attack)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Attack");
        }
    }

}
