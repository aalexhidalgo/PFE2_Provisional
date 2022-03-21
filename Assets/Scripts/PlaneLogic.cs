using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLogic : MonoBehaviour
{
    //Velocidades de los aviones
    private float RandomSpeed;
    private float MinSpeed = 10f;
    private float MaxSpeed = 20f;

    public AudioClip PlaneClip;
    private AudioSource PlayerAudioSource;

    public GameObject BombPrefab;

    private int RandomTime;

    private PlayerController PlayerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Velocidad random a cda avión
        RandomSpeed = Random.Range(MinSpeed, MaxSpeed);
        //Accedemos al PlayerController del jugador
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Accedemos al Audiosource del Player
        PlayerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        PlayerAudioSource.PlayOneShot(PlaneClip, 0.02f);

    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante en Z del avión
        transform.Translate(Vector3.forward * RandomSpeed * Time.deltaTime);

        //Si traspasa el límite, los aviones se van destruyendo
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
        //Si un proyectil alcanza una avión este y el proyectil se destruyen
        if (otherCollider.gameObject.CompareTag("Projectile"))
        {
            //Restamos 1 al contador de aviones
            PlayerControllerScript.PlaneCounter -= 1;
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }

        //Si los aviones cruzan el límite aéreo (Box Collider) empiezan a instanciar las bombas, siempre y cuando esté vivo el Player y no haya ganado
        if (otherCollider.gameObject.CompareTag("SkyLimit") && !PlayerControllerScript.GameOver && !PlayerControllerScript.Win)
        {
            StartCoroutine(RandomBombPos());
        }
    }
}
