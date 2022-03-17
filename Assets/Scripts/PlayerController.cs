using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    public float Speed = 2f;
    public float TurnSpeed = 15f;

    private Vector3 InitialPos = new Vector3(-223.580002f, -2.32999992f, -14.3199997f);

    public GameObject ProjectilePrefab;

    private AudioSource PlayerAudioSource;
    private AudioSource CameraAudioSource;

    public Animator PlayerAnimator;

    public bool GameOver;

    public int Live = 1000;

    private float YRotationLimit;
    private float MaxYRotationLimit = 45f;
    private float MinYRotationLimit = 135f;

    // Start is called before the first frame update
    void Start()
    {
        //Posición inicial
        //transform.position = InitialPos;
        GameOver = false;
        //Accedemos a la componente AudioSource del Player que recoge los efectos de sonido
        PlayerAudioSource = GetComponent<AudioSource>();
        //Accedemos al AudioSource de la Main Camera que recoge la música de fondo
        CameraAudioSource = GameObject.Find("My Cam").GetComponent<AudioSource>();
        //Accedemos a la componente AudioSource del Player que recoge las animaciones
        PlayerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Rotación de la cámara del Player con las teclas arriba, abajo o bien W, S
        VerticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Speed * Time.deltaTime * VerticalInput);

        //Con las teclas izquierda, derecha o bien A o D, controlamos la rotación del Player modificando así su dirección en Z
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime * HorizontalInput);

        //Límites del tanque, no puede girarse hacia atrás
        if (transform.rotation.y > MaxYRotationLimit)
        {
            transform.rotation = Quaternion.Euler(0, MaxYRotationLimit, 0);
        }

        if (transform.rotation.y > MinYRotationLimit)
        {
            transform.rotation = Quaternion.Euler(0, MinYRotationLimit, 0);
        }

        //Controlador del proyectil
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver)
        {
            Instantiate(ProjectilePrefab, transform.position , transform.rotation);
            PlayerAnimator.SetTrigger("Disparo");
        }
    }

    private void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Projectile") && otherTrigger.gameObject.CompareTag("Enemy"))
        {
            Destroy(otherTrigger.gameObject);
        }
    }
}
