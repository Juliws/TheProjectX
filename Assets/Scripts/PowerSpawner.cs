using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour, ISpawners<PoweController>
{
    public Spawner<PoweController> spawner;
    [SerializeField]
    MoverPersonaje player;

    // Start is called before the first frame update
    void Start()
    {
        spawner.Init(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && player.powerUpAttack)
        {
            spawner.Timing();
        }
    }
    public void OnItemActivated(SimplePool<PoweController> pool, PoweController item)
    {
        item.Init(pool);
        item.gameObject.SetActive(true);
    }
}
