using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public TransicionEscenas imageTransicionEscenas;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            this.GetComponent<Animator>().enabled = true;
            imageTransicionEscenas.EndLevel("_Calle1");
            GetComponent<AudioSource>().time = 12.8f;
            GetComponent<AudioSource>().Play();
        }
    }
}
