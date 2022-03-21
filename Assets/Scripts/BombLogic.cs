using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    //Velocidad de caída
    private float Speed = 5f;

    //Sistemas de partículas
    public ParticleSystem[] ExplosionParticleSystem;
    private ParticleSystem Explosion;
    
    //Recursos de sonido de la bomba
    private AudioSource PlayerAudioSource;
    public AudioClip ExplosionAudio;

    //Motor de animación de la bomba
    public Animator BombAnimator;

    //Variables del PlayerController
    private PlayerController PlayerControllerScript;

    void Start()
    {
        //Accedemos a la componente Player Controller y al AudioSource del Player que recoge los efectos de sonido
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        PlayerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();

        //Desde el principio ejecutamos una animación, como si estuviese apunto de detonarse
        BombAnimator = GetComponent<Animator>();
        BombAnimator.SetTrigger("PosicionY");
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento constante hacia abajo de la bomba
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    //Si la bomba toca al jugador explota y perdemos el juego
    private void OnTriggerEnter(Collider otherTrigger)
    {

        //Si conseguimos acertar la bomba con el proyectil, esta y el proyectil se destruyen
        if (otherTrigger.gameObject.CompareTag("Projectile") && !PlayerControllerScript.GameOver)
        {
            //Restamos 1 al contador de bombas
            PlayerControllerScript.BombCounter-= 1;
            Destroy(gameObject);
            Destroy(otherTrigger.gameObject);
        }

        //Si la bomba toca el suelo activamos la explosión y perdemos vida
        if (otherTrigger.gameObject.CompareTag("Ground") && !PlayerControllerScript.GameOver)
        {
            //Restamos 1 vida al contador
            PlayerControllerScript.LifeCounter -= 1;
            //Hacemos random la explosión
            int RandomIndex = Random.Range(0, 2);
            Explosion = Instantiate(ExplosionParticleSystem[RandomIndex], transform.position, ExplosionParticleSystem[RandomIndex].transform.rotation);
            Explosion.Play();
            //Activamos el clip de explosión
            PlayerAudioSource.PlayOneShot(ExplosionAudio, 0.1f);
            //Destruimos la bomba
            Destroy(gameObject);

            //Si caen 5 bombas, es decir, hemos perdido toda la vida, GAMEOVER
            if (PlayerControllerScript.LifeCounter == 0)
            {
                Destroy(gameObject);
                PlayerControllerScript.GameOver = true;
            }
        }
    }

}



