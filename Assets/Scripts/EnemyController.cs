using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float attackSpeed;
    [SerializeField]
    int damageAmount;
    [SerializeField]
    bool imABullet;
    [SerializeField]
    ParticleSystem effect;
    public AudioSource effectSound;

    void Start()
    {
    }
    void Attack(LifeController lifeController)
    {
        lifeController.ReceiveDamage(damageAmount);
    }

    void Update()
    {
        if (imABullet)
        {
            transform.position += transform.right * attackSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LifeController player))
        {
            Debug.Log("attack");

            Attack(player);
            if(this.TryGetComponent(out EnemyCaller enemyCaller))
            {
                enemyCaller.Recycle();
            }
        }
        else if (other.CompareTag("Wall"))
        {
            if (this.TryGetComponent(out EnemyCaller enemyCaller))
            {
                enemyCaller.Recycle();
            }
        }
        else if (other.CompareTag("PowerSparkles"))
        {
            if (this.TryGetComponent(out EnemyCaller enemyCaller))
            {
                effect.Play();
                enemyCaller.Recycle();
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}
