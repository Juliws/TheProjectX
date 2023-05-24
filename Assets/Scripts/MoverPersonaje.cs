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
    PowerSpawner powerSpawner;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] private Collider colliderDePie;
    [SerializeField] public Transform giroCharacterChild;
    [SerializeField] public Transform giroCharacterTeen;
    [SerializeField] private Quaternion giroAtras;
    [SerializeField] private Quaternion giroFrente;

    [Header("Salto")]
    [SerializeField] private float jumpForce = 15.0f;
    [SerializeField] private GameObject checkGround;
    [SerializeField] private bool enElSuelo;

    [Header("Agachado")]
    [SerializeField] private Collider colliderAgachado;
    [SerializeField] public bool agachado = false;
    [SerializeField] public bool estaAgachado = false;

    [Header("PowerUpsCheck")]
    [SerializeField] private bool powerUpJump;
    [SerializeField] private bool powerUpCrouch;
    [SerializeField] private bool powerUpAttack;
    [SerializeField] private GameObject child;
    [SerializeField] private GameObject teen;
    [SerializeField] private Animator teenAnim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerRb = GetComponent<Rigidbody>();
        powerSpawner = GetComponentInChildren<PowerSpawner>();
    }

    void Update()
    {
        //MoverPlayer();
        ComprobarPowerUps(); //Comprueba si ha adquirido los power ups para activar la habilidad correspondiente

        //Correr();
        //Jump();
        //Ataque();
       
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameStates == GameStates.GameOver)
        {
            return;
        }
        
        MoverPlayer();
        //ComprobarPowerUps();
    }

    private void MoverPlayer() // Metodo para mover el personaje
    {
        x = Input.GetAxisRaw("Horizontal"); //Obtiene el input para moverse horizontalmente

        transform.Translate(x * Time.deltaTime * velocidadMovimiento, 0, 0); //Recibe el input para mover el personaje de manera horizontal
        anim.SetFloat("VelX", x);
        teenAnim.SetFloat("VelX", x);

        /*Vector3 direction = GetComponent<Rigidbody>().velocity;

        direction.y = playerRb.velocity.y;
        playerRb.velocity = direction;*/

        //Giro del personaje izquierda
        if (x < 0)
        {
            giroCharacterChild.transform.rotation = giroAtras;
            giroCharacterTeen.transform.rotation = giroAtras;
        }
        //Giro del personaje derecha
        else if (x > 0)
        {
            giroCharacterChild.transform.rotation = giroFrente;
            giroCharacterTeen.transform.rotation = giroFrente;
        }

    }

    void ComprobarPowerUps() //Metodo para comprobar si puede usar las habilidades despues de obtener el powerup
    {
        if (powerUpJump == true)
        {
            Jump();
        }
        if (powerUpCrouch == true)
        {
            Agachado();
        }
        if (powerUpAttack == true)
        {
            Ataque();
        }
        if(powerUpJump & powerUpCrouch & powerUpAttack)
        {
            child.gameObject.SetActive(false);
            teen.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        enElSuelo = true;
    }

    /*private void OnCollisionExit(Collision collision) // Metodo para detectar que al no colisionar con el piso de como resultado a que este en el aire
    {
        enelSuelo = false;
        anim.SetBool("OnAir", true);
    }*/

    private void OnTriggerEnter(Collider other) // Metodo que determina despues de tomar el power up para cambiar el estado a verdadero
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            enElSuelo = true;
            anim.SetBool("OnAir", false);
            teenAnim.SetBool("OnAir", false);
        }

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

    private void OnTriggerExit(Collider other) //Metodo para corroborar que el personaje esta tocando el suelo
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            enElSuelo = false;
            anim.SetBool("OnAir", true);
            teenAnim.SetBool("OnAir", true);
        }
    }
    public void Jump() // Metodo de salto
    {
        if (Input.GetKey(KeyCode.Space) && enElSuelo)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            enElSuelo = false;
            anim.SetTrigger("Jump");
            teenAnim.SetTrigger("Jump");
        }
    }

    public void Agachado() // Metodo para activar y desactivar el area de un collider
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            agachado = true;
            //estaAgachado = true;
            colliderAgachado.enabled = true;
            anim.SetBool("Crouch", true);
            teenAnim.SetBool("Crouch", true);
            colliderDePie.enabled = false;
            Debug.Log("Agachado");
        }
        else if (estaAgachado == true)
        {
            agachado = true;
            colliderAgachado.enabled = true;
            anim.SetBool("Crouch", true);
            teenAnim.SetBool("Crouch", true);
            colliderDePie.enabled = false;
            Debug.Log("AG");
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            estaAgachado = false;
            agachado = false;
            colliderAgachado.enabled = false;
            colliderDePie.enabled = true;
            anim.SetBool("Crouch", false);
            teenAnim.SetBool("Crouch", false);
            Debug.Log("De Pie");
        }
    }

    public void Ataque() // Metodo para atacar
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKey(KeyCode.JoystickButton3))
        {
            anim.SetTrigger("Attack");
            teenAnim.SetTrigger("Attack");
            powerSpawner.Shot();
        }
    }

}
