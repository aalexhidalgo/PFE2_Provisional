using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    public float Speed = 5f;
    private float Ground = 0f;

    // Añadir audio + sistema de partículas de explosion

    public ParticleSystem ExplosionParticleSystem;
    public AudioClip ExplosionAudio;

    private AudioSource CameraAudioSource;

    public int BombDamage = 50;
    private float RandomBombLife;

    private PlayerController PlayerControllerScript;

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante hacia abajo de la bomba
        //transform.Translate(Vector3.down * Speed * Time.deltaTime);

        //Si la bomba toca el suelo activamos la explosión
        if (transform.position.y < Ground)
        {
            //ExplosionParticleSystem.Play();
            //CameraAudioSource.PlayOneShot(ExplosionAudio, 1);
            Destroy(gameObject);
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
        }

    }

}



