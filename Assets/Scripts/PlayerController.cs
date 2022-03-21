using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Controlador principal del Player (ejes y velocidades)
    private float HorizontalInput;
    private float VerticalInput;
    private GameObject AtrasPivote;
    private float Speed = 60f;
    private float TurnSpeed = 50f;
    
    //Posición inicial
    private Vector3 InitialPos = new Vector3(-229.939362f, 1.39999998f, -7.5999999f);

    //Proyectil
    public GameObject ProjectilePrefab;
    private GameObject ProjectilePivote;

    //Recursos de Sonido del Player
    private AudioSource PlayerAudioSource;
    private AudioSource CameraAudioSource;
    public AudioClip ShootProjectile;

    //Motor de animación del Player
    public Animator PlayerAnimator;

    //Fin del juego, puedes ganar o perder
    public bool Win;
    public bool GameOver;

    //Contadores que afectan al Player
    public int LifeCounter = 5;
    public int BombCounter = 50;
    public int PlaneCounter = 30;

    // Start is called before the first frame update
    void Start()
    {
        //Posición inicial
        transform.position = InitialPos;
        GameOver = false;
        //Accedemos a la componente AudioSource del Player que recoge los efectos de sonido
        PlayerAudioSource = GetComponent<AudioSource>();
        //Accedemos al AudioSource de la Main Camera que recoge la música de fondo
        CameraAudioSource = GameObject.Find("My Cam").GetComponent<AudioSource>();
        //Accedemos a la componente AudioSource del Player que recoge las animaciones
        PlayerAnimator = GetComponent<Animator>();
        //Accedemos al empty de atrás
        AtrasPivote = GameObject.Find("Atras");
        //Accedemos al empty de la punta
        ProjectilePivote = GameObject.Find("Projectile");

    }

    // Update is called once per frame
    void Update()
    {
        //Rotación del cañón del Player con las teclas arriba, abajo o bien W, S
        VerticalInput = Input.GetAxis("Vertical");
        AtrasPivote.transform.Rotate(Vector3.left * Speed * Time.deltaTime * VerticalInput);

        //Con las teclas izquierda, derecha o bien A o D, controlamos la rotación del Player modificando así su dirección en Z
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime * HorizontalInput);

        //Controlador del proyectil
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver && !Win)
        {
           Instantiate(ProjectilePrefab, ProjectilePivote.transform.position , AtrasPivote.transform.rotation);
           PlayerAudioSource.PlayOneShot(ShootProjectile, 0.2f);
           PlayerAnimator.SetTrigger("Disparo");
        }

        //Si los contadores de las bombas y los aviones llegan a 0 hemos ganado el juego
        if (BombCounter <= 0 && PlaneCounter <= 0)
        {
            Win = true;
        }

        //Si ganamos o perdemos paralizamos los efectos de so
        if (Win || GameOver)
        {
            PlayerAudioSource.Stop();
            CameraAudioSource.Stop();
        }
    }
}
