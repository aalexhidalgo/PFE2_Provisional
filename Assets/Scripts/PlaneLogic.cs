using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLogic : MonoBehaviour
{
    public float RandomSpeed;
    private float MinSpeed = 10f;
    private float MaxSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad random a cda avión
        RandomSpeed = Random.Range(MinSpeed, MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante en Z del avión
        transform.Translate(Vector3.forward * RandomSpeed * Time.deltaTime);

        //Si traspasa el límite los aviones se van destruyendo
        float ZDestroyLimit = 500f;
        float YDestroyLimit = 80f;
        float XDestroyLimit = 22f;

        if (transform.position.x > XDestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > YDestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > ZDestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -XDestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -YDestroyLimit)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -ZDestroyLimit)
        {
            Destroy(gameObject);
        }

        
    }
}
