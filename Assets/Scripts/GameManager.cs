using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Panel GAMEOVER
    public GameObject GameOverPanel;
    //Panel WIN
    public GameObject WinPanel;
    //Panel de JUEGO
    public GameObject GamePanel;

    //Texto de los contadores
    public TextMeshProUGUI Life;
    public TextMeshProUGUI Aviones;
    public TextMeshProUGUI Bombas;

    //Opciones MENU

    //Iniciamos el juego y pasamos a la escena de juego
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

    //Variables del PlayerController
    private PlayerController PlayerControllerScript;

    void Start()
    {
        //Accedemos al PlayerController y activamos el panel de juego
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(false);

    }

    void Update()
    {
        //Los contadores se irán actualizando a medida que el jugador vaya cumpliendo las condiciones
        Life.text = $"{PlayerControllerScript.LifeCounter}";
        Aviones.text = $"{PlayerControllerScript.PlaneCounter}";
        Bombas.text = $"{PlayerControllerScript.BombCounter}";

        //Si los contadores de las bombas o los aviones llegan a 0, sobreescribimos el texto para evitar valores negativos
        if (PlayerControllerScript.PlaneCounter <= 0)
        {
            Aviones.text = "0";
        }

        if (PlayerControllerScript.BombCounter <= 0)
        {
            Bombas.text = "0";
        }

        //Si el jugador muere activamos el panel de GAMEOVER
        if (PlayerControllerScript.GameOver)
        {
            GamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }

        //Si el jugador gana activamos el panel de WIN
        if(PlayerControllerScript.Win)
        {
            GamePanel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }

}