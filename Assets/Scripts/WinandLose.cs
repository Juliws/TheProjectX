using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinandLose : MonoBehaviour
{
    [Header("Won Logic")]
    [SerializeField] private GameObject wonObject;
    [SerializeField] private GameObject wonScreen;

    [Header("Lose Logic")]
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
        
        if (GameManager.Instance.gameStates == GameStates.GameOver)
        {
            loseScreen.SetActive(true);
        }
    }

    void PauseMenu()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
        

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinObject"))
        {
            wonScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
