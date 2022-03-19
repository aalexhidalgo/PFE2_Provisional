using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PlanePrefab;

    //L�mites a�reos en los cuales pueden aparecer los aviones
    private float YUpLimit = 40f; 
    private float YDownLimit = 25f;
    private float ZMaxLimit = 30f;
    private float ZMinLimit = -30f;
    private float XStartPos = 0f;

    private float StartAfterTime = 1f;
    private float RepeatRate = 2f;
    void Start()
    {
        //Cada cuanto va a spawnearse uno de los aviones
        InvokeRepeating("SpawnRandomPlane", StartAfterTime, RepeatRate);
        //A�adir invocar prefabs bombas y ejecutar animaci�n escotillas
    }
    public Vector3 RandomSpawnPosition()
    {
        //Hacemos random la posici�n en la cual puede Spawnear seg�n los l�mites
        float RandomSpawnPosY = Random.Range(YDownLimit, YUpLimit);
        float RandomSpawnPosZ = Random.Range(ZMinLimit, ZMaxLimit);
        return new Vector3(XStartPos, RandomSpawnPosY, RandomSpawnPosZ);
    }

    //L�mites de rotaci�n del avi�n
    private float RandomXLimit = 10f;
    private float RandomZLimit = 10f;

    private Quaternion RandomRotationAxis()
    {
        return Quaternion.Euler(Random.Range(-RandomXLimit, RandomXLimit), 270f, Random.Range(-RandomZLimit, RandomZLimit));
    }

    public void SpawnRandomPlane()
    {
        Instantiate(PlanePrefab, RandomSpawnPosition(), RandomRotationAxis());
    }
}
