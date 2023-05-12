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
    public void Init(SimplePool<EnemyController> _pool)
    {
        pool = _pool;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LifeController player))
        {
            Attack(player);
        }
        else if (other.CompareTag("Wall"))
        {
            pool.Recycling(this);
            gameObject.SetActive(false);
            transform.position = initialPos;
        }
    }
}
