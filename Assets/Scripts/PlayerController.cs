using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    public float Speed = 70f;
    public float TurnSpeed = 50f;

    private Vector3 InitialPos = new Vector3(-229.939362f, 1.39999998f, -7.5999999f);

    public GameObject ProjectilePrefab;

    private AudioSource PlayerAudioSource;
    private AudioSource CameraAudioSource;
    public AudioClip ShootProjectile;

    public Animator PlayerAnimator;

    public bool Win;
    public bool GameOver;

    public int BombDamage = 5;
    public int BombCounter = 50;
    public int PlaneCounter = 30;

    private GameObject AtrasPivote;
    private GameObject ProjectilePivote;

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
        ProjectilePivote = GameObject.Find("Projectile");

    }

    // Update is called once per frame
    void Update()
    {
        //Rotación de la cámara del Player con las teclas arriba, abajo o bien W, S
        VerticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Speed * Time.deltaTime * VerticalInput);
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

        if (BombCounter <= 0 && PlaneCounter <= 0)
        {
            Win = true;
        }

        if (Win || GameOver)
        {
            PlayerAudioSource.Stop();
            CameraAudioSource.Stop();
        }
    }
}
