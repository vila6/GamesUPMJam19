using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEndGame : MonoBehaviour
{
    public Respirador myRespirador;
    public AudioSource ventana;
    public AudioSource morirse;
    public GameObject barra;
    public GameObject creditos;
    public AudioSource playerAudioSource;
    private bool endReached = false;

    void Start()
    {
        StartCoroutine(EndGame());
    }

    void Update()
    {
        if(endReached && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private IEnumerator EndGame()
    {
        playerAudioSource.volume = 0f;
        yield return new WaitForSeconds(1.5f);
        ventana.Play();
        yield return new WaitForSeconds(4f);
        ventana.Stop();
        morirse.Play();
        yield return new WaitForSeconds(0.5f);
        for(int i = 0 ; i < 20 ; i ++)
        {
            myRespirador.ChangeSize(10 + i);
            yield return new WaitForSeconds(0.2f + i*0.05f);
        }
        
        barra.SetActive(false);   
        yield return new WaitForSeconds(5f);
        creditos.SetActive(true);
        endReached = true;
    }
}
