using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Color Red = Color.red;
    public Color Default = Color.white;
    public float YLimit = 15f;
    [SerializeField] private float EverySecond = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Activar animaci�n de cambio de color

        if (transform.position.y < YLimit)
        {
            GetComponent<MeshRenderer>().material.color = Red;

            //Hacer que parpadee el efecto de que est� a punto de explotar

            //GetComponent<MeshRenderer>().material.color = Color.white; (activar cada segundo)

        }
    }

}
