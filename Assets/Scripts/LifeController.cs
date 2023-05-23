using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    int initialLife;
    public int life;

    void Start()
    {
        life = initialLife;
    }
    public void ReceiveDamage(int damageAmount)
    {
        Debug.Log("received damage" + damageAmount);
        GameManager.Instance.OnLifeChange(true, life);
        life -= damageAmount;
    }

    public void Heal(int healingAmount)
    {
        GameManager.Instance.OnLifeChange(false, life);
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
