using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private int maiorPontuacao;
    public float currentTime = 30;

    [SerializeField]
    private float startTime;

    [SerializeField]
    private Text textoScore;
    [SerializeField]
    private Text textoHighcore;

    public bool gameStarted = false;

    [SerializeField]
    private GameObject panelMainMenu;
    [SerializeField]
    private GameObject panelPlay;
    [SerializeField]
    private GameObject panelPause;
    [SerializeField]
    private GameObject panelGameOver;

    private Hat hat;

    private void Start()
    {
        hat = FindObjectOfType<Hat>();
        currentTime = startTime;
        maiorPontuacao = PlayerPrefs.GetInt("highscore");
        textoHighcore.text = $"Highscore: {maiorPontuacao}";
        maiorPontuacao.ToString();
        textoScore.text = score.ToString();
    }

    private void Update()
    {
        CountDownTime();

        if(currentTime <= 0 & gameStarted)
        {
            panelPlay.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void Pontuar()
    {
        score++;
        textoScore.text = score.ToString();
    }

    public void CountDownTime()
    {
        if(currentTime > 0 && gameStarted)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            gameStarted = false;
            Time.timeScale = 0;
            SaveScore();
        }
        
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    public void ButtonStartGame()
    {
        Reiniciar();
        panelMainMenu.SetActive(false);
        panelPlay.SetActive(true);
        panelGameOver.SetActive(false);
        currentTime = startTime;
        gameStarted = true;
        Time.timeScale = 1;
    }

    public void ButtonPause()
    {
        panelPause.SetActive(true);
        panelPlay.SetActive(false);        
        gameStarted = false;
        Time.timeScale = 0;
    }

    public void ButtonResume()
    {
        panelPlay.SetActive(true);
        panelPause.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1;
    }

    public void ButtonBackMainMenu()
    {
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelMainMenu.SetActive(true);        

        Reiniciar();
    }

    private void SaveScore()
    {
        if(score > maiorPontuacao)
        {
            PlayerPrefs.SetInt("highscore", score);
        }        
    }   

    private void Reiniciar()
    {
        score = 0;
        textoScore.text = score.ToString();
        hat.ReiniciarPosicao();

        var bolas = FindObjectsOfType<Ball>();
        foreach (var bola in bolas)
        {
            bola.DestruirObjeto();
        }
    }
}
