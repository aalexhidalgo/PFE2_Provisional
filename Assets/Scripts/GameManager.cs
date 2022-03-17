using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Panel GAMEOVER
    public GameObject GameOverPanel;
    public GameObject HowToPlayPanel;
    public GameObject MainMenuPanel;

    //Opciones MENU

    //Iniciamos el juego y pasamos a la escena que toca
    public void StartButton()
    {
        SceneManager.LoadScene("Juego");
    }
    //Configuramos libremente el juego
    public void HowToPlayButton()
    {
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        HowToPlayPanel.SetActive(true);
    }

    //Salimos del juego
    public void ExitButton()
    {
        Application.Quit();
    }

    //Dentro de Options: Para salir de las opciones
    public void ReturnButton()
    {
        HowToPlayPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //Recargamos la escena de juego
    public void RestartButton()
    {
        SceneManager.LoadScene("Juego");
    }

    private PlayerController PlayerControllerScript;

    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        MainMenuPanel.SetActive(true);
    }

    void Update()
    {
        if(!PlayerControllerScript.GameOver)
        {
            GameOverPanel.SetActive(true);
        }
    }

}
