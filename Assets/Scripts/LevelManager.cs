using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Codigo de cambio de escena🔁
    public void ChangeScence(string Scena)
    {
        SceneManager.LoadScene(Scena);
        GameManager.Instance.gameStates = GameStates.GameStart;
    }
    //Boton de pausa 🛑
    public void Stop() 
    {
        Time.timeScale = 0;
        Debug.Log("Pausado");
    }
    //Boton de continuar ⏩
    public void Continue()
    {
        Time.timeScale = 1;
        Debug.Log("Continuado");
    }
    //Boton de Reiniciar 🔁
    public void Restart()
    {
        Time.timeScale = 1;
        GameManager.Instance.gameStates = GameStates.GameStart;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciado");
    }
    //Boton de Cerrar ❌
    public void Cerrar()
    {
        Application.Quit();
        Debug.Log("Cerrado");
    }
}
