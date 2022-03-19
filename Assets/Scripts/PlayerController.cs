using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    public float Speed = 70f;
    public float TurnSpeed = 50f;

    private Vector3 InitialPos = new Vector3(-223.580002f, -2.32999992f, -14.3199997f);

    public GameObject ProjectilePrefab;

    private AudioSource PlayerAudioSource;
    private AudioSource CameraAudioSource;
    public AudioClip ShootProjectile;

    public Animator PlayerAnimator;

    public bool GameOver;

    public int Live = 1000;

    private GameObject AtrasPivote;
    private GameObject ProjectilePivote;

    // Start is called before the first frame update
    void Start()
    {
        //Posici�n inicial
        //transform.position = InitialPos;
        GameOver = false;
        //Accedemos a la componente AudioSource del Player que recoge los efectos de sonido
        PlayerAudioSource = GetComponent<AudioSource>();
        //Accedemos al AudioSource de la Main Camera que recoge la m�sica de fondo
        CameraAudioSource = GameObject.Find("My Cam").GetComponent<AudioSource>();
        //Accedemos a la componente AudioSource del Player que recoge las animaciones
        PlayerAnimator = GetComponent<Animator>();
        //Accedemos al empty de atr�s
        AtrasPivote = GameObject.Find("Atras");
        ProjectilePivote = GameObject.Find("Projectile");

    }

    // Update is called once per frame
    void Update()
    {
        //Rotaci�n de la c�mara del Player con las teclas arriba, abajo o bien W, S
        VerticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Speed * Time.deltaTime * VerticalInput);
        AtrasPivote.transform.Rotate(Vector3.left * Speed * Time.deltaTime * VerticalInput);

        //Con las teclas izquierda, derecha o bien A o D, controlamos la rotaci�n del Player modificando as� su direcci�n en Z
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime * HorizontalInput);

        //Controlador del proyectil
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
           Instantiate(ProjectilePrefab, ProjectilePivote.transform.position , AtrasPivote.transform.rotation);
           PlayerAudioSource.PlayOneShot(ShootProjectile, 0.2f);
           PlayerAnimator.SetTrigger("Disparo");
        }
    }
}
