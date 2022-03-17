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

        float ZDetonateBomb = 100f;

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

        //Instanciar bomba entre 0 a 5segundos (que esté cerca del jugador), abrir compuertas con animación
        if (transform.position.z == ZDetonateBomb)
        {
            StartCoroutine(RandomBombPos());
        }

    }

    public IEnumerator RandomBombPos()
    {
        RandomTime = Random.Range(0, 5);
        yield return new WaitForSeconds(RandomTime);
        Instantiate(BombPrefab, transform.position, BombPrefab.transform.rotation);
    }
}
