using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCaller : MonoBehaviour
{
    SimplePool<EnemyCaller> pool;
    Vector3 initialPos;
    EnemyController enemyController;

    public void Init(SimplePool<EnemyCaller> _pool)
    {
        TryGetComponent(out enemyController);
        initialPos = transform.position;
        pool = _pool;
        enemyController.effectSound.PlayOneShot(enemyController.effectSound.clip);

    }
    public void Recycle()
    {
        pool.Recycling(this);
        gameObject.SetActive(false);
        enemyController.mycollider.enabled = true;
        transform.position = initialPos;
    }
}
