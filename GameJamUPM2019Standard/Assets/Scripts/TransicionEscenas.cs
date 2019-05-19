using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscenas : MonoBehaviour
{
    public void StartLevel()
    {
        this.GetComponent<Animator>().enabled = true;
    }


    public void EndLevel(string nextScene)
    {
        StartCoroutine(RoutineEnd(nextScene));
    }

    private IEnumerator RoutineEnd(string nextScene)
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().SetTrigger("FundidoANegro");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(nextScene);        
    }
}
