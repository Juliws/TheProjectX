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
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip back;
    [SerializeField] private bool pauseGame= false;

    // Start is called before the first frame update
    void Start()
    {
        pauseBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStates == GameStates.GameOver)
        {
            loseScreen.SetActive(true);
            pauseBtn.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;
            if (!pauseGame)
            {
                Continue();
            }
            else
            {
                PauseMenu();
            }
        }
    }

    void PauseMenu()
    {
        pauseGame = true;
        sound.PlayOneShot(back);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseBtn.SetActive(false);
    }

    void Continue()
    {
        pauseGame = false;
        sound.PlayOneShot(back);
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
    }
        

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinObject"))
        {
            wonScreen.SetActive(true);
            pauseBtn.SetActive(false);
            Time.timeScale = 0f;
        }

        if (collision.gameObject.CompareTag("Falling"))
        {
            loseScreen.SetActive(true);
            pauseBtn.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
