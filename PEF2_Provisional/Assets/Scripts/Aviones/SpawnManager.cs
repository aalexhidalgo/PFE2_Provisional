using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;

    //L�mites a�reos en los cuales pueden aparecer los aviones
    private float YUpLimit = 60f; 
    private float YDownLimit = 20f;
    private float ZLimit = 40f;
    private float XLimit = 40f;

    private float StartAfterTime = 1f;
    private float RepeatRate = 2f;

    public Vector3 RandomSpawnPosition()
    {
        //Hacemos random la posici�n en la cual puede Spawnear seg�n los l�mites
        float RandomSpawnPosX = Random.Range(-XLimit, XLimit);
        float RandomSpawnPosY = Random.Range(-YUpLimit, YDownLimit);
        float RandomSpawnPosZ = Random.Range(-ZLimit, ZLimit);
        return new Vector3(RandomSpawnPosX, RandomSpawnPosY, RandomSpawnPosZ);
    }

    //L�mites de rotaci�n del avi�n
    private float RandomXLimit = 20f;
    private float RandomZLimit = 30f;

    private Quaternion RandomRotationAxis()
    {
        return Quaternion.Euler(Random.Range(-RandomXLimit, RandomXLimit), 0f, Random.Range(-RandomZLimit, RandomZLimit));
    }

    void Start()
    {
        //Cada cuanto va a spawnearse uno de los aviones
        InvokeRepeating("SpawnRandomPlane", StartAfterTime, RepeatRate);
        //A�adir invocar prefabs bombas y ejecutar animaci�n escotillas
    }
    
    public void SpawnRandomPlane()
    {
        //Lista en caso de a�adir m�s de un tipo de avi�n
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        Instantiate(targetPrefabs[randomIndex],
            RandomSpawnPosition(), RandomRotationAxis());
    }

    //if the distance between the player and the plane is narrow, the plane opens the cabine and trows the bomb to make damage to the player
}
