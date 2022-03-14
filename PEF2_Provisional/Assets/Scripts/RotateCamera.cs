using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotar con el Mouse de forma horizontal y vertical, controla la visión del jugador

        float HorizontalInputMouse = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime * HorizontalInputMouse);
        float VerticalInputMouse = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.left, RotationSpeed * Time.deltaTime * VerticalInputMouse);

    }
}
