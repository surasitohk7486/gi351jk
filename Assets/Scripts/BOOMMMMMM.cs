using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOMMMMMM : MonoBehaviour
{
    [SerializeField] GameObject gbLight;
    
    [SerializeField] GameObject time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gbLight.SetActive(true);
        
        time.SetActive(true);
        Destroy(gameObject);
    }
}
