using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject menuInicio;
    public GameObject creditosScreen;
    public GameObject controlesScreen;

    public void StartGame()
    {
        SceneManager.LoadScene("");
        menuInicio.SetActive(false);

    }

}
