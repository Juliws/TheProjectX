using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class Spawner<T> where T : Component
{
    public SimplePool<T> pool;
    [SerializeField]
    float timer;
    [SerializeField]
    float spawnTime;
    ISpawners<T> owner;
    [SerializeField]
    bool randomPos;
    [SerializeField]
    float randomPosRange;

    public void Init(ISpawners<T> _owner)
    {
        owner = _owner;
        pool.Init();
    }

    public void Timing()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }
    public void Spawn()
    {
        var newItem = pool.ActivatingItem();
        newItem.gameObject.SetActive(true);
        if (randomPos)
        {
            var ranPos = Random.Range(randomPosRange, -randomPosRange);
            newItem.transform.position += newItem.transform.up * ranPos;
        }
        else
        {
            newItem.transform.position = owner.transform.position;
        }
        owner.OnItemActivated(pool, newItem);
    }

}

public interface ISpawners<T> where T : Component
{
    public Transform transform
    {
        get;
    }
    public void OnItemActivated(SimplePool<T> pool, T item);
}
