using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawners<EnemyController>
{
    public Spawner<EnemyController> spawner;
    void Start()
    {
        spawner.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        spawner.Timing();
    }

    public void OnItemActivated(SimplePool<EnemyController> pool, EnemyController item)
    {
        
    }

}
