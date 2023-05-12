using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    int initialLife;
    [SerializeField]
    int life;

    void Start()
    {
        life = initialLife;
    }
    public void ReceiveDamage(int damageAmount)
    {
        Debug.Log("received damage" + damageAmount);
        life -= damageAmount;
    }

    public void Heal(int healingAmount)
    {
        life += healingAmount;
    }
    
    void Update()
    {
        if(life <= 0)
        {
            GameManager.Instance.gameStates = GameStates.GameOver;
            Debug.Log("Game Over");
        }
    }
}
