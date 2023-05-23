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
        effect.gameObject.SetActive(false);

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
                StartCoroutine(OnShot(enemyCaller));
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
    }
    IEnumerator OnShot(EnemyCaller enemyCaller)
    {
        effect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        enemyCaller.Recycle();

    }
}
