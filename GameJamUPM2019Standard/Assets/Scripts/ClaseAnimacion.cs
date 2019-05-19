using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseAnimacion : MonoBehaviour
{

    public GameObject player;
    public float waitTime;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim=player.GetComponent<Animator>()
        waitTime=3f;
        player.GetComponent<Respirador>().enabled=false;
        player.GetComponent<PlayerController>().enabled=false;
        StartCoroutine(wait());
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
       // player
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
