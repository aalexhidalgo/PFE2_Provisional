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
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(false);

    }

    void Update()
    {
        Life.text = $"{PlayerControllerScript.BombDamage}";
        Aviones.text = $"{PlayerControllerScript.PlaneCounter}";
        Bombas.text = $"{PlayerControllerScript.BombCounter}";

        if (PlayerControllerScript.PlaneCounter <= 0)
        {
            Aviones.text = "0";
        }

        if (PlayerControllerScript.BombCounter <= 0)
        {
            Bombas.text = "0";
        }

        if (PlayerControllerScript.GameOver)
        {
            GamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }

        if(PlayerControllerScript.Win)
        {
            GamePanel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }

}