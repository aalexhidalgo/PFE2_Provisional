using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Panel GAMEOVER
    public GameObject GameOverPanel;
    

    //Opciones MENU

    //Iniciamos el juego y pasamos a la escena que toca
    public void StartButton()
    {
        SceneManager.LoadScene("Juego");
    }

    //Salimos del juego
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    //Recargamos la escena de juego
    public void RestartButton()
    {
        SceneManager.LoadScene("Juego");
    }

    private PlayerController PlayerControllerScript;

    void Start()
    {
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(PlayerControllerScript.GameOver == true)
        {
            GameOverPanel.SetActive(true);
        }
    }

}