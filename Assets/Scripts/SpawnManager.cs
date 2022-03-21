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

    //Variables del PlayerController
    private PlayerController PlayerControllerScript;

    void Start()
    {
        //Cuando se va a spawnear el primer avi�n y en que frecuencia se van a spawnear el resto
        InvokeRepeating("SpawnRandomPlane", StartAfterTime, RepeatRate);
        //Accedemos al PlayerController del jugador 
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

    //Hacemos random la posici�n en la cual pueden spawnear seg�n los l�mites a�reos
    public Vector3 RandomSpawnPosition()
    {
        float RandomSpawnPosY = Random.Range(YDownLimit, YUpLimit);
        float RandomSpawnPosZ = Random.Range(ZMinLimit, ZMaxLimit);
        return new Vector3(XStartPos, RandomSpawnPosY, RandomSpawnPosZ);
    }

    //L�mites de rotaci�n del avi�n
    private float RandomXLimit = 5f;
    private float RandomZLimit = 10f;

    //Hacemos random la rotaci�n en la cual pueden spawnear seg�n los l�mites de rotaci�n
    private Quaternion RandomRotationAxis()
    {
        return Quaternion.Euler(Random.Range(-RandomXLimit, RandomXLimit), 270f, Random.Range(-RandomZLimit, RandomZLimit));
    }

    //Le enchufamos al invoke el avi�n a instanciar, la posici�n random y la rotaci�n random
    public void SpawnRandomPlane()
    {
        Instantiate(PlanePrefab, RandomSpawnPosition(), RandomRotationAxis());
    }

    void Update()
    {
        //Tanto si hemos ganado como si hemos perdido cancelamos el invoke con tal de que no aparezcan m�s aviones en escena
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
