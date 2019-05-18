using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BreatheBar : MonoBehaviour
{
    public float inspire, expire, breatheTime, inputTrigger;
    public RectTransform inspireBar, expireBar, inspireExceedBar, expireExceedBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputTrigger = Input.GetAxis("RightTrigger");
        Debug.Log(inputTrigger);
    }
}
