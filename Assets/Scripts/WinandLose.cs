using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinandLose : MonoBehaviour
{
    [Header("Won Logic")]
    [SerializeField] private GameObject wonObject;
    [SerializeField] private GameObject wonScreen;

    [SerializeField] private GameObject loseScreen;

    [Header("Pause Logic")]
    [SerializeField] private GameObject pauseMenu;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu();
    }

    void PauseMenu()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WinObject")) 
        { 
            wonScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
