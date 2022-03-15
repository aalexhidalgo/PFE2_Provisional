using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    public float Speed = 2f;
    public float TurnSpeed = 15f;

    private Vector3 InitialPos = new Vector3(-249.119995f, -4.499146f, -4.30000019f);

    public GameObject ProjectilePrefab;

    private AudioSource PlayerAudioSource;
    private AudioSource CameraAudioSource;

    private Animator PlayerAnimator;

    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        //Posici�n inicial
        transform.position = InitialPos;
        //Accedemos a la componente AudioSource del Player que recoge los efectos de sonido
        PlayerAudioSource = GetComponent<AudioSource>();
        //Accedemos al AudioSource de la Main Camera que recoge la m�sica de fondo
        CameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //Accedemos a la componente AudioSource del Player que recoge las animaciones
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento hacia adelante del Player con las teclas arriba, abajo o bien W, S
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Speed * Time.deltaTime * VerticalInput);

        //Con las teclas izquierda, derecha o bien A o D, controlamos la rotaci�n del Player modificando as� su direcci�n en Z
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime * HorizontalInput);

        //Controlador del proyectil
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(ProjectilePrefab, transform.position, transform.rotation);
            //Destroy(EL PROYECTIL AL PASAR 4 SEGUNDOS);
            PlayerAnimator.SetTrigger("Disparo");
        }
    }
}
