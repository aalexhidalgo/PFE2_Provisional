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
        float DestroyLimit = -250f;

        if (transform.position.x < DestroyLimit)
        {
            Destroy(gameObject);
        }

    }

    //Instanciar bomba entre 0 a 3 segundos (que esté cerca del jugador)
    public IEnumerator RandomBombPos()
    {
        RandomTime = Random.Range(0, 3);
        yield return new WaitForSeconds(RandomTime);
        Instantiate(BombPrefab, transform.position, BombPrefab.transform.rotation);
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }

        if (otherCollider.gameObject.CompareTag("SkyLimit"))
        {
            Debug.Log("Funciono");
            StartCoroutine(RandomBombPos());
        }
    }
}
