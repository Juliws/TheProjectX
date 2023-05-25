using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawners<EnemyCaller>
{
    public Spawner<EnemyCaller> spawner;
    void Start()
    {
        spawner.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStates == GameStates.GameOver) return;
        spawner.Timing();
    }

    public void OnItemActivated(SimplePool<EnemyCaller> pool, EnemyCaller item)
    {
        item.Init(pool);
        item.gameObject.SetActive(true);

    }

}
