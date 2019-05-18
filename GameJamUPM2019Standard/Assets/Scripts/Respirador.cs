using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respirador : MonoBehaviour
{
    //max 150 y min -150
    private float oxigenAmount=0f;
    private float barraValue;
    private float breathingAxis;
    private float maxAmountOfOxigen=150f;
    public int counterOfActualBarra=0;
    public GameObject RojoContainer;
    public GameObject AzulContainer;
    private float activeRedChildren;
    private float activeBlueChildren;
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
            if(oxigenAmount+barraValue<150f)
            {
                oxigenAmount+=barraValue;
                if(counterOfActualBarra+1==0)
                {
                    counterOfActualBarra=1;
                }
                else
                {
                    counterOfActualBarra++;
                }
                
                //Si estas presionando y la barra está por encima del cero
                if(counterOfActualBarra>0) 
                {
                    RojoContainer.transform.GetChild(counterOfActualBarra-1).gameObject.SetActive(true);
                }
                //Si estas presionando y la barra esta por debajo del 0
                if(counterOfActualBarra<0 ) 
                {
                    AzulContainer.transform.GetChild((-counterOfActualBarra)).gameObject.SetActive(false);
                }
                if(counterOfActualBarra==1)
                {
                    AzulContainer.transform.GetChild(counterOfActualBarra-1).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if(oxigenAmount-barraValue>-150f)
            {
                oxigenAmount-=barraValue;
                if(counterOfActualBarra-1==0)
                {
                    counterOfActualBarra=-1;
                }
                else
                {
                    counterOfActualBarra--;
                }
                //Si estas sin presionar y la barra está por debajo del cero
                if(counterOfActualBarra<0 )
                {
                    AzulContainer.transform.GetChild((-counterOfActualBarra)-1).gameObject.SetActive(true);
                }
                //Si esta sin presionar y la barra está por encima del cero
                if(counterOfActualBarra>0 ) 
                {
                    RojoContainer.transform.GetChild(counterOfActualBarra).gameObject.SetActive(false);
                }
                if(counterOfActualBarra==-1)
                {
                    RojoContainer.transform.GetChild(counterOfActualBarra-1).gameObject.SetActive(false);
                }
            }
        }
    }
}
