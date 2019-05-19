using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsController : MonoBehaviour
{
    public AudioClip [] stepAudios;

    public void PlayRandomStep()
    {
        GetComponent<AudioSource>().clip = stepAudios[Random.Range(0, stepAudios.Length)];
        GetComponent<AudioSource>().Play();
        Debug.Log("Playing step");
    }
}
