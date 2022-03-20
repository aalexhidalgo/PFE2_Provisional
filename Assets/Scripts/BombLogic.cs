using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    public float Speed = 5f;

    // Añadir audio + sistema de partículas de explosion

    public ParticleSystem[] ExplosionParticleSystem;
    private ParticleSystem Explosion;
    public AudioClip ExplosionAudio;

    private AudioSource PlayerAudioSource;
    public Animator BombAnimator;

    private float RandomBombLife;
    private float StartDetonation = 8f;

    private PlayerController PlayerControllerScript;

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        BombAnimator = GetComponent<Animator>();

        PlayerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante hacia abajo de la bomba
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if (transform.position.y < StartDetonation)
        {
            BombAnimator.SetTrigger("PosicionY");
        }
    }

    //Si la bomba toca al jugador explota y perdemos el juego
    private void OnTriggerEnter(Collider otherTrigger)
    {

        //Si conseguimos acertar la bomba con el proyectil, esta se destruye
        if (otherTrigger.gameObject.CompareTag("Projectile") && !PlayerControllerScript.GameOver)
        {
            PlayerControllerScript.BombCounter-= 1;
            Debug.Log($"Bravo, la has destruido");
            Destroy(gameObject);
            Destroy(otherTrigger.gameObject);
        }

        //Si la bomba toca el suelo activamos la explosión
        if (otherTrigger.gameObject.CompareTag("Ground") && !PlayerControllerScript.GameOver)
        {
            PlayerControllerScript.BombDamage -= 1;
            int RandomIndex = Random.Range(0, 2);
            Explosion = Instantiate(ExplosionParticleSystem[RandomIndex], transform.position, ExplosionParticleSystem[RandomIndex].transform.rotation);
            Explosion.Play();
            PlayerAudioSource.PlayOneShot(ExplosionAudio, 0.1f);
            Destroy(gameObject);

            //Si caen 5 bombas, hemos perdido
            if (PlayerControllerScript.BombDamage == 0)
            {
                Debug.Log($"GAME OVER");
                Destroy(gameObject);
                PlayerControllerScript.GameOver = true;
            }
        }
    }

}



