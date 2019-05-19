using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] stepAudios;
    public AudioClip chokeAudio;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRandomStep()
    {
        source.clip = stepAudios[Random.Range(0, stepAudios.Length - 1)];
        source.Play();
    }

    public void PlayChokeAudio()
    {
        source.clip = chokeAudio;
        source.loop = true;
        source.Play();
    }

    public void StopAudio()
    {
        source.loop = false;
        source.Stop();
    }
}
