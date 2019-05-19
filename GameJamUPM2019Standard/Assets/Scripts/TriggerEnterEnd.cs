using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterEnd : MonoBehaviour
{
    public TransicionEscenas imageTransicionEscenas;
    public string nextSceneName;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            imageTransicionEscenas.EndLevel(nextSceneName);
        }
    }
}
