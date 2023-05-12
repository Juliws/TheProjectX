using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SimplePool<T> where T: Component
{
    [SerializeField]
    T prefab;
    [SerializeField]
    Transform parent;
    [SerializeField]
    int initSize;
    [SerializeField]
    List<T> itemsInPool = new List<T>();
    List<bool> activeItems = new List<bool>();

    public void Init()
    {
        GenerateInPool(initSize);
    }

    public void GenerateInPool(int growBy)
    {
        for (int i = 0; i < growBy; i++)
        {
            var newItem = GameObject.Instantiate(prefab, parent);
            itemsInPool.Add(newItem);
            activeItems.Add(false);
            newItem.gameObject.SetActive(false);
        }
    }
    public T ActivatingItem()
    {
        for (int i = 0; i < itemsInPool.Count; i++)
        {
            if (!activeItems[i])
            {
                activeItems[i] = true;
                return itemsInPool[i];
            }
        }
        var lastItemAdded = itemsInPool.Count;
        GenerateInPool(5);
        activeItems[lastItemAdded] = true;
        return itemsInPool[lastItemAdded];
    }


    public void Recycling(T usedItem)
    {
        var idx = itemsInPool.IndexOf(usedItem);
        activeItems[idx] = false;
    }
}
