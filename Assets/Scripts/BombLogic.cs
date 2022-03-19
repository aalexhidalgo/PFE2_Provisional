using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    public float Speed = 5f;

    // Añadir audio + sistema de partículas de explosion

    public ParticleSystem BigExplosionParticleSystem;
    public ParticleSystem SmallExplosionParticleSystem;
    public AudioClip ExplosionAudio;

    private AudioSource PlayerAudioSource;
    public Animator BombAnimator;

    public int BombDamage = 100;
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
        if (otherTrigger.gameObject.CompareTag("Player") && !PlayerControllerScript.GameOver)
        {
            PlayerControllerScript.Live -= BombDamage;
            Debug.Log($"Tienes {PlayerControllerScript.Live} de vida, ouuuuch!");
            Destroy(gameObject);

            if (PlayerControllerScript.Live == 0)
            {
                Debug.Log($"GAME OVER");
                Destroy(gameObject);
                PlayerControllerScript.GameOver = true;
            }
        }

        //Si conseguimos acertar la bomba con el proyectil, esta se destruye
        if (otherTrigger.gameObject.CompareTag("Projectile") && !PlayerControllerScript.GameOver)
        {
            Debug.Log($"Bravo, la has destruido");
            Destroy(gameObject);
            Destroy(otherTrigger.gameObject);
        }

        //Si la bomba toca el suelo activamos la explosión
        if (otherTrigger.gameObject.CompareTag("Ground") && !PlayerControllerScript.GameOver)
        {
            Instantiate(BigExplosionParticleSystem, transform.position, BigExplosionParticleSystem.transform.rotation);
            BigExplosionParticleSystem.Play();
            PlayerAudioSource.PlayOneShot(ExplosionAudio, 0.1f);
            Destroy(gameObject);
        }
    }

}



