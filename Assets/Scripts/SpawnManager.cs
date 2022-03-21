using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PlanePrefab;

    //Límites aéreos en los cuales pueden aparecer los aviones
    private float YUpLimit = 40f; 
    private float YDownLimit = 25f;
    private float ZMaxLimit = 30f;
    private float ZMinLimit = -30f;
    private float XStartPos = 0f;

    private float StartAfterTime = 1f;
    private float RepeatRate = 2f;

    //Variables del PlayerController
    private PlayerController PlayerControllerScript;

    void Start()
    {
        //Cuando se va a spawnear el primer avión y en que frecuencia se van a spawnear el resto
        InvokeRepeating("SpawnRandomPlane", StartAfterTime, RepeatRate);
        //Accedemos al PlayerController del jugador 
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

    //Hacemos random la posición en la cual pueden spawnear según los límites aéreos
    public Vector3 RandomSpawnPosition()
    {
        float RandomSpawnPosY = Random.Range(YDownLimit, YUpLimit);
        float RandomSpawnPosZ = Random.Range(ZMinLimit, ZMaxLimit);
        return new Vector3(XStartPos, RandomSpawnPosY, RandomSpawnPosZ);
    }

    //Límites de rotación del avión
    private float RandomXLimit = 5f;
    private float RandomZLimit = 10f;

    //Hacemos random la rotación en la cual pueden spawnear según los límites de rotación
    private Quaternion RandomRotationAxis()
    {
        return Quaternion.Euler(Random.Range(-RandomXLimit, RandomXLimit), 270f, Random.Range(-RandomZLimit, RandomZLimit));
    }

    //Le enchufamos al invoke el avión a instanciar, la posición random y la rotación random
    public void SpawnRandomPlane()
    {
        Instantiate(PlanePrefab, RandomSpawnPosition(), RandomRotationAxis());
    }

    void Update()
    {
        //Tanto si hemos ganado como si hemos perdido cancelamos el invoke con tal de que no aparezcan más aviones en escena
        if(PlayerControllerScript.GameOver == true)
        {
            CancelInvoke("SpawnRandomPlane");
        }

        if (PlayerControllerScript.Win == true)
        {
            CancelInvoke("SpawnRandomPlane");
        }

    }
}
