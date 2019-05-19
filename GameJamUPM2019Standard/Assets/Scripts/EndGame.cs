using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject EndCanvas;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            EndCanvas.SetActive(true);    
        }        
    }
}
