using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour, ISpawners<PoweController>
{
    public Spawner<PoweController> spawner;
    [SerializeField]
    MoverPersonaje player;
    [SerializeField]
    Transform powerPrefabSpot;

    // Start is called before the first frame update
    void Start()
    {
        spawner.Init(this);
    }

    public void Shot()
    {
        spawner.Timing();

    }
    public void OnItemActivated(SimplePool<PoweController> pool, PoweController item)
    {
        item.Init(pool);
        item.gameObject.SetActive(true);
        item.transform.right = pool.parent.transform.right;
        item.gameObject.transform.SetParent(powerPrefabSpot);
    }
}
