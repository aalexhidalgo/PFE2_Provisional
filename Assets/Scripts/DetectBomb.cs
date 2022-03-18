using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBomb : MonoBehaviour
{
    private int BombCounter = 20;

    private PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider otherTrigger)
    {
        if (otherTrigger.gameObject.CompareTag("Bomb") && !PlayerControllerScript.GameOver)
        {
            BombCounter -= 1;
            //ExplosionParticleSystem.Play();
            //CameraAudioSource.PlayOneShot(ExplosionAudio, 1);
            Destroy(otherTrigger.gameObject);
            if (BombCounter == 0)
            {
                PlayerControllerScript.GameOver = true;
            }
        }
    }
}
