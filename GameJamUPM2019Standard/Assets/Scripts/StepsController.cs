using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsController : MonoBehaviour
{
    public AudioClip [] stepAudios;

    public void PlayRandomStep()
    {
        GetComponent<AudioSource>().clip = stepAudios[Random.Range(0, stepAudios.Length - 1)];
        GetComponent<AudioSource>().Play();
        Debug.Log("Playing step");
    }
}
