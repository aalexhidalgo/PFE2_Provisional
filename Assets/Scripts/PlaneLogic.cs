using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLogic : MonoBehaviour
{
    public float RandomSpeed;
    private float MinSpeed = 10f;
    private float MaxSpeed = 20f;

    public GameObject BombPrefab;

    private int RandomTime;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad random a cda avi�n
        RandomSpeed = Random.Range(MinSpeed, MaxSpeed);
        StartCoroutine(RandomBombPos());
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante en Z del avi�n
        transform.Translate(Vector3.forward * RandomSpeed * Time.deltaTime);

        //Si traspasa el l�mite los aviones se van destruyendo
        float DestroyLimit = -250f;

        if (transform.position.x < DestroyLimit)
        {
            Destroy(gameObject);
        }

    }

    //Instanciar bomba entre 0 a 3 segundos (que est� cerca del jugador), abrir compuertas con animaci�n
    public IEnumerator RandomBombPos()
    {
        RandomTime = Random.Range(0, 3);
        yield return new WaitForSeconds(RandomTime);
        Instantiate(BombPrefab, transform.position, BombPrefab.transform.rotation);
    }
}
