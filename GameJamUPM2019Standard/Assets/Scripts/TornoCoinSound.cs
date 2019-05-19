using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornoCoinSound : MonoBehaviour
{
    public AudioClip coinSound;
    private bool hasSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(!hasSound)
        {
            hasSound=true;
            this.GetComponent<AudioSource>().PlayOneShot(coinSound);
        }
        
    }
}
