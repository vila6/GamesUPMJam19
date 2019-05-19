using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageEndGame : MonoBehaviour
{
    public Respirador myRespirador;
    public AudioSource ventana;
    public AudioSource morirse;
    public GameObject barra;
    void Start()
    {
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
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
    }
}
