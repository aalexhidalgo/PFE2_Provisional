using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float RandomSpeed;
    private float MinSpeed = 5f;
    private float MaxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad random a cda avi�n
        RandomSpeed = Random.Range(MinSpeed, MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante en Z del avi�n
        transform.Translate(Vector3.forward * RandomSpeed * Time.deltaTime);

        //Si traspasa el l�mite los aviones se van destruyendo

        float DestroyLimit = 100f;

        if (transform.position.x > DestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > DestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > DestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -DestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -DestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -DestroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
