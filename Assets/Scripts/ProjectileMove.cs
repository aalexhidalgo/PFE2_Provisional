using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    //Velocidad proyectil
    private float Speed = 70f;
    void Update()
    {
        //Movimiento constante hacia adelante del Proyectil
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
