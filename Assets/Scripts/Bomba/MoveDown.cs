using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float Speed = 5f;
    public float Ground = 0f; //(IsOntheGround???)

    // A�adir audio + sistema de part�culas de explosion

    public ParticleSystem ExplosionParticleSystem;
    public AudioClip ExplosionAudio;

    private AudioSource CameraAudioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante hacia abajo de la bomba
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        //Si la bomba toca el suelo activamos la explosi�n
        if (transform.position.y < Ground)
        {
            //ExplosionParticleSystem.Play();
            //CameraAudioSource.PlayOneShot(ExplosionAudio, 1);
            Destroy(gameObject);
        }
    }
}
