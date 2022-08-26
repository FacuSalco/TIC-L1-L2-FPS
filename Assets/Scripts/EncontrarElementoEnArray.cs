using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarElementoEnArray : MonoBehaviour
{
    //1. Crear un array public de GameObject
    public GameObject[] arrayDeMesas; //Crear array publico

    // Start is called before the first frame update
    void Start()
    {
        //2. Asignar todos los objetods tageados como "Mesa" en el array
        arrayDeMesas = GameObject.FindGameObjectsWithTag("Mesa"); //Meter todos los objetos dentro del array que tengan el TAG "Mesa"
        AddMesaScriptAndSetDestructible();
    }

    // Update is called once per frame
    void Update()
    {
        //4. Invocar la funcion al presioaar el cero alfanumerico
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //DeactivateObjectsInArray();
            DestroyDestructible();
        }
    }
    //3. Crear una funcion que desactive todos los elementos del array
    void DeactivateObjectsInArray() //Desactivar todos los objetos del array
    {
        for (int i = 0; i < arrayDeMesas.Length; i++)
        {
            arrayDeMesas[i].SetActive(false);
        }
    }

    //5. Crear una funcion que asigne a todos los elementos del array
    //el script "Mesa". Establecer el valor e la variable "destructible" aleatoriamente

    void AddMesaScriptAndSetDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            go.AddComponent<Mesa>();
            go.GetComponent<Mesa>().destructible = Random.Range(0, 2) == 0;
        }
    }

    //6. Crear una funcion que destruya el elemento del array que contenga un script "Mesa"
    //cuya variable booleana "destructible" sea true (crear el script "Mesa")

    void DestroyDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            if (go.GetComponent<Mesa>().destructible) //si la variable destructible es true...
            {
                Destroy(go);
            }
        }
    }
}
