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
    public Collider mycollider;
    [SerializeField]
    ParticleSystem effect;
    public AudioSource effectSound;

    void Start()
    {
        effect.gameObject.SetActive(false);
        TryGetComponent(out mycollider);
        if (!mycollider.enabled) mycollider.enabled = mycollider.enabled;
        
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
            mycollider.enabled = !mycollider.enabled;
            Attack(player);
            StartCoroutine(OnShot());
            
        }
        else if (other.CompareTag("Ground"))
        {

        }
        else if (other.CompareTag("PowerSparkles"))
        {
            StartCoroutine(OnShot());
        }
    }
    void Recycle()
    {
        gameObject.SetActive(false);
    }
    IEnumerator OnShot()
    {
        effect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        if (this.TryGetComponent(out EnemyCaller enemyCaller))
        {
            enemyCaller.Recycle();
        }
        else
        {
            Recycle();
        }
    }
}
