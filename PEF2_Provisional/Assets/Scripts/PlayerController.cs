using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    public float Speed = 2f;
    public float TurnSpeed = 15f;

    private Vector3 InitialPos = new Vector3(-249.119995f, -3.66000009f, -4.30000019f);

    public GameObject ProjectilePrefab;

    private AudioSource PlayerAudioSource;
    private AudioSource CameraAudioSource;

    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        //Posición inicial
        transform.position = InitialPos;
        //Accedemos a la componente AudioSource del Player que recoge los efectos de sonido
        PlayerAudioSource = GetComponent<AudioSource>();
        //Accedemos al AudioSource de la Main Camera que recoge la música de fondo
        CameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        //Hasta que no acabe con la oleada de aviones no se empieza a mover
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento hacia adelante del Player con las teclas arrib, abajo o bien W, S
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Speed * Time.deltaTime * VerticalInput);

        //Con las teclas izquierda, derecha o bien A o D, controlamos la rotación del Player modificando así su dirección en Z
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * TurnSpeed * Time.deltaTime * HorizontalInput);


        //if Planes cross the limits stop spawning
    }

    //Controlador del proyectil
    public void OnMouseDown()
    {
        Instantiate(ProjectilePrefab, transform.position, gameObject.transform.rotation);
    }
}
