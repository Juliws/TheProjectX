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
    [SerializeField] private float jumpForce = 15.0f;
    [SerializeField] private bool enelSuelo;

    [Header("Agachado")]
    [SerializeField] private Transform controlTecho;
    [SerializeField] private Collider colliderAgachado;
    [SerializeField] private bool agachado = false;
    [SerializeField] private bool estaAgachado = false;

    [Header("PowerUpsCheck")]
    [SerializeField] private bool powerUpJump;
    [SerializeField] private bool powerUpCrouch;
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
        ComprobarPowerUps(); //Comprueba si ha adquirido los power ups para activar la habilidad correspondiente
        //Correr();
        //Jump();
        //Ataque();
    }

    private void MoverPlayer() // Metodo para mover el personaje
    {
        x = Input.GetAxisRaw("Horizontal"); //Obtiene el input para moverse horizontalmente
        //y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0); //Recibe el input para mover el personaje de manera horizontal

        anim.SetFloat("VelX", x);
        
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

    void ComprobarPowerUps() //Metodo para comprobar si puede usar las habilidades despues de obtener el powerup
    {
        if (powerUpJump==true)
        {
            Jump();
        }
        if (powerUpCrouch==true)
        {
            Agachado();
        }
        if (powerUpAttack==true)
        {
            Ataque();
        }
    }

    private void OnCollisionEnter(Collision collision) // condicion para ver si hay contacto con el suelo (para la logica del salto)
    {
        enelSuelo = true;
        if (collision.gameObject.CompareTag("BendWall"))
        {
            estaAgachado = true;
            anim.SetBool("Crouch", true);
            colliderAgachado.enabled = true;
            colliderDePie.enabled = false;
            Debug.Log("Si estoy debajo");
        }
        else 
        {
            estaAgachado = false; 
            anim.SetBool("Crouch", false);
            colliderAgachado.enabled = false;
            colliderDePie.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) // Metodo que determina despues de tomar el power up para cambiar el estado a verdadero
    {
        if (other.gameObject.CompareTag("PwrupJump"))
        {
            powerUpJump = true;
            Debug.Log("Puedes Saltar");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PwrupCrouch"))
        {
            powerUpCrouch = true;
            Debug.Log("Puedes Agacharte");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("PwrupAttack"))
        {
            powerUpAttack = true;
            Debug.Log("Puedes Atacar");
            Destroy(other.gameObject);
        }
    }
    public void Jump() // Metodo de salto
    {
        if (Input.GetKey(KeyCode.Space) && enelSuelo)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enelSuelo = false;
            anim.SetTrigger("Jump");
        }
       
    }

    public void Agachado() // Metodo para activar y desactivar el area de un collider
    {
        if (Input.GetKey(KeyCode.DownArrow))//Input.GetKey(KeyCode.S))
        {
            agachado = true;
            //estaAgachado = true;
            colliderAgachado.enabled = true;
            anim.SetBool("Crouch", true);
            colliderDePie.enabled = false;
            Debug.Log("Agachado");
        }/*else if (estaAgachado==true) 
        {
            agachado = true;
            colliderAgachado.enabled = true;
            anim.SetBool("Crouch", true);
            colliderDePie.enabled = false;
            Debug.Log("AG");
        }*/
        else
        {
            agachado = false;
            //estaAgachado = false;
            colliderAgachado.enabled = false;
            colliderDePie.enabled = true;
            anim.SetBool("Crouch", false);
            Debug.Log("De Pie");
        }
    }

    public void Ataque() // Metodo para atacar
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetTrigger("Attack");
        }
    }

}
