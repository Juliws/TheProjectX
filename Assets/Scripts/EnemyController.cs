using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    SimplePool<EnemyController> pool;
    [SerializeField]
    float attackSpeed;
    [SerializeField]
    int damageAmount;
    Vector3 initialPos;
    [SerializeField]
    AudioSource firingSound;
    public void Init(SimplePool<EnemyController> _pool)
    {
        pool = _pool;
        firingSound.PlayOneShot(firingSound.clip);
    }
    void Start()
    {
        initialPos = transform.position;
    }
    void Attack(LifeController lifeController)
    {
        lifeController.ReceiveDamage(damageAmount);
    }

    void Update()
    {
        transform.position += transform.right * attackSpeed * Time.deltaTime;
    }
    void Recycle()
    {
        pool.Recycling(this);
        gameObject.SetActive(false);
        transform.position = initialPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LifeController player))
        {
            Debug.Log("attack");

            Attack(player);
            Recycle();
        }
        else if (other.CompareTag("Wall"))
        {
            Recycle();
        }

    }
}
