using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //Tiempo de vida
    private float Time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Una vez instanciado el proyectil si traspasa su tiempo de vida este se autodestruye
        Destroy(gameObject, Time);
    }
}
