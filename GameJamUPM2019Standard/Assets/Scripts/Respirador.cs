using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Si quieres cambiar de tamaño de uno pequeño a uno mas grande tienes que reinstanciar el prefab y llamar al changeSize de ese nuevo objeto
//El tamaño máximo es de 30 barras (30 azules y 30 rojas)
public class Respirador : MonoBehaviour
{
    //max 150 y min -150
    public float oxigenAmount=0f;
    public float amountOfBarras=30f;
    private float barraValue=10f;
    private float breathingAxis;
    private float maxAmountOfOxigen=150f;
    public GameObject RojoContainer;
    public GameObject AzulContainer;
    public GameObject RespiracionFondo;
    private int activeRedChildren;
    private int activeBlueChildren;
    public float timeThicc=0.2f;
    private float fondoHeight;
    public float amountOfBarrasToChange=20f;
    private bool hasReachLimit;

    // Start is called before the first frame update
    void Start()
    {
        hasReachLimit=false;
        InvokeRepeating("Breathing",2f,timeThicc);
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void Breathing()
    {
        maxAmountOfOxigen=amountOfBarras*barraValue;
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
                if(oxigenAmount > 0) 
                {
                    RojoContainer.transform.GetChild(activeRedChildren).gameObject.SetActive(true);
                }
                //NO BORRAR ESTOS COMENTARIOS, IMPORTANTE
                //Si estas presionando y la barra esta en el ultimo rojo
                // if(oxigenAmount>0 && oxigenAmount==maxAmountOfOxigen ) 
                // {
                //     RojoContainer.transform.GetChild(activeRedChildren).gameObject.SetActive(true);
                // }
                //Si estas presionando y la barra esta por debajo del 0
                if(oxigenAmount <= 0) 
                {
                    Debug.Log(activeBlueChildren);
                    AzulContainer.transform.GetChild(activeBlueChildren - 1).gameObject.SetActive(false);
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
                if(oxigenAmount < 0)
                {
                    AzulContainer.transform.GetChild(activeBlueChildren).gameObject.SetActive(true);
                }
                //NO BORRAR ESTOS COMENTARIOS, IMPORTANTE
                //Si no estas presionando y la barra esta en el ultimo azul
                // if(oxigenAmount<0 && -oxigenAmount==maxAmountOfOxigen ) 
                // {
                //     AzulContainer.transform.GetChild(activeBlueChildren).gameObject.SetActive(true);
                // }
                //Si esta sin presionar y la barra está por encima del cero
                if(oxigenAmount >= 0) 
                {
                    RojoContainer.transform.GetChild(activeRedChildren - 1).gameObject.SetActive(false);
                }
            }
        }

        //Mira a ver que sacas en claro
        if(-oxigenAmount==maxAmountOfOxigen || oxigenAmount==maxAmountOfOxigen)
        {
            hasReachLimit=true;
        }

    }

    void changeSize(float amountToChangeTo)
    {
        CancelInvoke("Breathing");
        fondoHeight=RespiracionFondo.GetComponent<RectTransform>().rect.height;
        //Reinicio de
        for(int i=0;i<RojoContainer.transform.childCount;i++)
         {
             RojoContainer.transform.GetChild(i).gameObject.SetActive(false);
         }
         for(int i=0;i<AzulContainer.transform.childCount;i++)
         {
             AzulContainer.transform.GetChild(i).gameObject.SetActive(false);
         }

        //RespiracionFondo.GetComponent<RectTransform>().sizeDelta=new Vector2(RespiracionFondo.GetComponent<RectTransform>().sizeDelta.x,(RespiracionFondo.GetComponent<RectTransform>().sizeDelta.y*((amountOfBarras-amountToChangeTo)*fondoHeight)/amountOfBarras))/100;
        //print(Mathf.Abs((amountOfBarras*2)-(amountToChangeTo*2)));
        //print(fondoHeight);
        //print(amountOfBarras);
        //print( ( ( (amountOfBarras*2)-Mathf.Abs( (amountOfBarras*2)-(amountToChangeTo*2) ) )*RespiracionFondo.GetComponent<RectTransform>().sizeDelta.y)/(amountOfBarras*2) );
        
        
        print(( ( (amountOfBarras*2)-Mathf.Abs( (amountOfBarras*2)-(amountToChangeTo*2) ) )*RespiracionFondo.GetComponent<RectTransform>().sizeDelta.y)/(amountOfBarras*2));
        RespiracionFondo.GetComponent<RectTransform>().sizeDelta=new Vector2(RespiracionFondo.GetComponent<RectTransform>().sizeDelta.x,( ( (amountOfBarras*2)-Mathf.Abs( (amountOfBarras*2)-(amountToChangeTo*2) ) )*RespiracionFondo.GetComponent<RectTransform>().sizeDelta.y)/(amountOfBarras*2));
        amountOfBarras=amountToChangeTo;
        maxAmountOfOxigen=amountOfBarras*barraValue;
        InvokeRepeating("Breathing",2f,timeThicc);

    }

}
