using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    /*[SerializeField] private float RotationSpeed = 500f;
    private float XRotationLimit;

    private float MaxRotationLimit= 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotar con el Mouse de forma horizontal y vertical, controla la visi�n del jugador

        float HorizontalInputMouse = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime * HorizontalInputMouse);
        float VerticalInputMouse = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.left, RotationSpeed * Time.deltaTime * VerticalInputMouse);


        //L�mites c�mara, no puede girarse hacia atr�s
        XRotationLimit -= VerticalInputMouse;
        XRotationLimit = Mathf.Clamp(XRotationLimit, -MaxRotationLimit, MaxRotationLimit);
        transform.localRotation = Quaternion.Euler(XRotationLimit, 0, 0);
        
    }
        */
}
