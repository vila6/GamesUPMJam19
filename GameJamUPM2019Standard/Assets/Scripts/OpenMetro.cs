using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMetro : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetTrigger("Open");
    }
}
