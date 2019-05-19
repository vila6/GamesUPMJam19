using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Si quieres cambiar de tamaño de uno pequeño a uno mas grande tienes que reinstanciar el prefab y llamar al changeSize de ese nuevo objeto
//El tamaño máximo es de 30 barras (30 azules y 30 rojas)
public class Respirador : MonoBehaviour
{
    //max 150 y min -150
    public float oxigenAmount=0f;
    [Range(0,30)]
    public int amountOfBarras = 30;
    private float barraValue = 1f; // Y el premio, a la variable mas inutil, innecesaria y estupida, va para... esta variable \o/
    private float breathingAxis;
    private float maxAmountOfOxigen=150f;
    public GameObject RojoContainer;
    public GameObject AzulContainer;
    public GameObject RespiracionFondo;
    private int activeRedChildren;
    private int activeBlueChildren;
    public float timeThicc = 0.2f;
    private float fondoHeight;
    private bool lastTimeTakingAir = false;
    public PlayerController playerController;
    private bool isOnFailure = false;
    private bool failureWithFullPulmon;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Breathing",0f,timeThicc);
        ChangeSize(amountOfBarras);
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

        // Aire pa dentro (mantener pulsado)
        breathingAxis=Input.GetAxis("Breath");
        if(breathingAxis!=0)
        {
            if(isOnFailure && (failureWithFullPulmon == false && oxigenAmount > 0))
            {
                Recovery();
            }
            else
            {
                // Si coges aire con el pulmon lleno es fallo
                if(!lastTimeTakingAir && oxigenAmount > 0)
                {
                    Failure(true);
                }
            }
            
            lastTimeTakingAir = true;

            if(oxigenAmount + barraValue <= maxAmountOfOxigen)
            {
                oxigenAmount += barraValue;   
                
                //Si estas presionando y la barra está por encima del cero
                if(oxigenAmount > 0) 
                {
                    RojoContainer.transform.GetChild(activeRedChildren).gameObject.SetActive(true);
                }
                //Si estas presionando y la barra esta por debajo del 0
                if(oxigenAmount <= 0) 
                {
                    AzulContainer.transform.GetChild(activeBlueChildren - 1).gameObject.SetActive(false);
                }
            }
        }
        // Aire pa fuera (soltando boton)
        else
        {
            if(isOnFailure && (failureWithFullPulmon == true && oxigenAmount < 0))
            {
                Recovery();
            }
            else
            {
                // Si sueltas aire con el pulmon vacio es fallo 
                if(lastTimeTakingAir && oxigenAmount < 0)
                {
                    Failure(false);
                }
            }
            
            lastTimeTakingAir = false;

            if(oxigenAmount-barraValue>=-maxAmountOfOxigen)
            {
                oxigenAmount-=barraValue;
                //Si estas sin presionar y la barra está por debajo del cero
                if(oxigenAmount < 0)
                {
                    AzulContainer.transform.GetChild(activeBlueChildren).gameObject.SetActive(true);
                }
                //Si esta sin presionar y la barra está por encima del cero
                if(oxigenAmount >= 0) 
                {
                    RojoContainer.transform.GetChild(activeRedChildren - 1).gameObject.SetActive(false);
                }
            }
        }

        // Si las barras llegan a los limites
        if(oxigenAmount <= -maxAmountOfOxigen)
        {
            Failure(false);
        }
        else if(oxigenAmount >= maxAmountOfOxigen)
        {
            Failure(true);
        }

    }

    public void ChangeSize(float amountToChangeTo)
    {
        if(amountToChangeTo > 30)
        {
            Debug.LogError("No se pue tanta barra");
        }
        else
        {
            float estimacionAOjoDelTamañoDeUnaBarra = 3.25f;
            RespiracionFondo.GetComponent<RectTransform>().sizeDelta = new Vector2(RespiracionFondo.GetComponent<RectTransform>().sizeDelta.x , amountToChangeTo * estimacionAOjoDelTamañoDeUnaBarra);
            maxAmountOfOxigen = amountOfBarras * barraValue;
        }

        /*
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
        */
    }

    private void Failure(bool state)
    {
        playerController.StartFailureState();
        isOnFailure = true;
        failureWithFullPulmon = state; // Para saber si necesita(true) o le falta(false) aire
    }

    private void Recovery()
    {
        playerController.EndFailureState();
        isOnFailure = false;
    }

}
