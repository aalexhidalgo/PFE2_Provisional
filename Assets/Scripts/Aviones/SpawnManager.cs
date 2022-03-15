using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;

    //Límites aéreos en los cuales pueden aparecer los aviones
    private float YUpLimit = 80f; 
    private float YDownLimit = 60f;
    private float ZMaxLimit = 20f;
    private float ZMinLimit = -20f;
    private float XMinLimit = 60f;
    private float XMaxLimit = 400f;

    private float StartAfterTime = 1f;
    private float RepeatRate = 2f;

    public Vector3 RandomSpawnPosition()
    {
        //Hacemos random la posición en la cual puede Spawnear según los límites
        float RandomSpawnPosX = Random.Range(XMinLimit, XMaxLimit);
        float RandomSpawnPosY = Random.Range(YDownLimit, YUpLimit);
        float RandomSpawnPosZ = Random.Range(ZMinLimit, ZMaxLimit);
        return new Vector3(RandomSpawnPosX, RandomSpawnPosY, RandomSpawnPosZ);
    }

    //Límites de rotación del avión
    private float RandomXLimit = 10f;
    private float RandomZLimit = 10f;

    private Quaternion RandomRotationAxis()
    {
        return Quaternion.Euler(Random.Range(-RandomXLimit, RandomXLimit), 270f, Random.Range(-RandomZLimit, RandomZLimit));
    }

    void Start()
    {
        //Cada cuanto va a spawnearse uno de los aviones
        InvokeRepeating("SpawnRandomPlane", StartAfterTime, RepeatRate);
        //Añadir invocar prefabs bombas y ejecutar animación escotillas
    }
    
    public void SpawnRandomPlane()
    {
        //Lista en caso de añadir más de un tipo de avión
        int randomIndex = Random.Range(0, targetPrefabs.Length);
        Instantiate(targetPrefabs[randomIndex],
            RandomSpawnPosition(), RandomRotationAxis());
    }

    //if the distance between the player and the plane is narrow, the plane opens the cabine and trows the bomb to make damage to the player
}
