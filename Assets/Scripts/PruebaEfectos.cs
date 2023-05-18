using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaEfectos : MonoBehaviour
{
    public GameObject vfxPower;
    // Start is called before the first frame update
    void Start()
    {
        vfxPower.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            vfxPower.gameObject.SetActive(true);
        }
    }
}
