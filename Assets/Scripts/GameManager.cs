﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    public LifeController player;
    public GameStates gameStates;
    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                DestroyImmediate(this);
            }
        }
        instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
public enum GameStates
{
    GamemMenu,
    GameStart,
    GameOver
}
