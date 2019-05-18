using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respirador : MonoBehaviour
{
    //max 150 y min -150
    public float oxigenAmount=0f;
    private float barraValue;
    private float breathingAxis;
    private float maxAmountOfOxigen=150f;
    public GameObject RojoContainer;
    public GameObject AzulContainer;
    private int activeRedChildren;
    private int activeBlueChildren;
    public float timeThicc=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Breathing",2f,timeThicc);
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void Breathing()
    {
         barraValue=maxAmountOfOxigen/RojoContainer.transform.childCount;
         activeBlueChildren=0;
         activeRedChildren=0;
         for(int i=0;i<RojoContainer.transform.childCount;i++)
         {
             if(RojoContainer.transform.GetChild(i).gameObject.activeSelf)
                 activeRedChildren++;
         }
         for(int i=0;i<AzulContainer.transform.childCount;i++)
         {
             if(AzulContainer.transform.GetChild(i).gameObject.activeSelf)
                 activeBlueChildren++;
         }
        //Respiratorio
        breathingAxis=Input.GetAxis("Breath");
        if(breathingAxis!=0)
        {
            if(oxigenAmount+barraValue<=maxAmountOfOxigen)
            {
                oxigenAmount+=barraValue;   
                
                //Si estas presionando y la barra está por encima del cero
                if(oxigenAmount>0 && oxigenAmount<maxAmountOfOxigen ) 
                {
                    RojoContainer.transform.GetChild(activeRedChildren+1).gameObject.SetActive(true);
                }
                //NO BORRAR ESTOS COMENTARIOS, IMPORTANTE
                //Si estas presionando y la barra esta en el ultimo rojo
                // if(oxigenAmount>0 && oxigenAmount==maxAmountOfOxigen ) 
                // {
                //     RojoContainer.transform.GetChild(activeRedChildren).gameObject.SetActive(true);
                // }
                //Si estas presionando y la barra esta por debajo del 0
                if(oxigenAmount<0 && -oxigenAmount<maxAmountOfOxigen ) 
                {
                    AzulContainer.transform.GetChild(activeBlueChildren).gameObject.SetActive(false);
                }
            }
        }
        //Si no presionas
        else
        {
            if(oxigenAmount-barraValue>=-maxAmountOfOxigen)
            {
                oxigenAmount-=barraValue;
                //Si estas sin presionar y la barra está por debajo del cero
                if(oxigenAmount<0 && -oxigenAmount<maxAmountOfOxigen)
                {
                    AzulContainer.transform.GetChild(activeBlueChildren+1).gameObject.SetActive(true);
                }
                //NO BORRAR ESTOS COMENTARIOS, IMPORTANTE
                //Si no estas presionando y la barra esta en el ultimo azul
                // if(oxigenAmount<0 && -oxigenAmount==maxAmountOfOxigen ) 
                // {
                //     AzulContainer.transform.GetChild(activeBlueChildren).gameObject.SetActive(true);
                // }
                //Si esta sin presionar y la barra está por encima del cero
                if(oxigenAmount>0 && oxigenAmount!=maxAmountOfOxigen) 
                {
                    RojoContainer.transform.GetChild(activeRedChildren).gameObject.SetActive(false);
                }
            }
        }
    }
}
