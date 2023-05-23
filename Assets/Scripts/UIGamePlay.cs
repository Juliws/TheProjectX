using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGamePlay : MonoBehaviour
{
    [SerializeField]
    Transform lifeElementsSource;
    List<Transform> lifeElements = new List<Transform>();
    List<bool> isElementActive = new List<bool>();
    void Start()
    {
        var elements = lifeElementsSource.GetComponentsInChildren<Transform>();
        for (int i = 0; i < elements.Length; i++)
        {
            lifeElements.Add(elements[i]);
            isElementActive.Add(true);
        }
        Debug.Log(lifeElements.Count + "elements");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLife(bool lostLife, int currLife)
    {
        if (lostLife)
        {
            DisableElement(currLife);
        }
        else if (!lostLife)
        {
            EnanableElement(currLife);
        }
    }
    void EnanableElement(int idx)
    {
        var element = idx - 1;
        isElementActive[element] = true;
        lifeElements[element].gameObject.SetActive(true);
        /*
        for (int i = 0; i < lifeElements.Count; i++)
        {
            if (!isElementActive[i])
            {
                isElementActive[i] = true;
                lifeElements[i].gameObject.SetActive(true);
                break;
            }
        }*/
    }
    void DisableElement(int idx)
    {
        var element = idx - 1;
        isElementActive[element] = false;
        lifeElements[element].gameObject.SetActive(false);
        /*
        for (int i = 0; i < lifeElements.Count; i++)
        {
            if (isElementActive[i])
            {
                isElementActive[i] = false;
                lifeElements[i].gameObject.SetActive(false);
                break;
            }
        }*/
    }
}
