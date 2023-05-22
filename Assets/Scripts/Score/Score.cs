using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    private TMP_Text scoreText;
        
    public float score;
        
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        scoreText.text = score.ToString("0");
    }
    

    public void sumarPuntos(float puntos)
    {
        score += puntos;        
    }


    public void ShowgameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    
}
