using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweController : MonoBehaviour
{
    SimplePool<PoweController> pool;
    [SerializeField]
    float powerSpreadSpeed;
    float timer;
    float lifeSpan = 10;
    public void Init(SimplePool<PoweController> simplePool)
    {
        pool = simplePool;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeSpan)
        {
            Recycling();
        }
        transform.position += transform.right * powerSpreadSpeed * Time.deltaTime;
    }
    void Recycling()
    {
        pool.Recycling(this);
        this.gameObject.SetActive(false);
    }
}
