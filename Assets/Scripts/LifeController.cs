using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField]
    int initialLife;
    int life;

    void Start()
    {
        life = initialLife;
    }
    public void ReceiveDamage(int damageAmount)
    {
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
            //Game over condition
        }
    }
}
