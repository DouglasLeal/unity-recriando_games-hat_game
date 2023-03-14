using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;
    public float currentTime = 30;

    [SerializeField]
    private float startTime;

    public bool gameStarted = false;

    [SerializeField]
    private GameObject panelMainMenu;
    [SerializeField]
    private GameObject panelPlay;
    [SerializeField]
    private GameObject panelPause;
    [SerializeField]
    private GameObject panelGameOver;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        CountDownTime();

        if(currentTime <= 0)
        {
            panelPlay.SetActive(false);
            panelGameOver.SetActive(true);
        }
    }

    public void Pontuar()
    {
        score++;
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
        }
        
    }

    public void ButtonExit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ButtonStartGame()
    {
        panelMainMenu.SetActive(false);
        panelPlay.SetActive(true);
        currentTime = startTime;
        gameStarted = true;
    }

    public void ButtonPause()
    {
        panelPlay.SetActive(false);
        panelPause.SetActive(true);
        gameStarted = false;
    }

    public void ButtonResume()
    {
        panelPlay.SetActive(true);
        panelPause.SetActive(false);
        gameStarted = true;
    }

    public void ButtonBackMainMenu()
    {
        panelMainMenu.SetActive(true);
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
    }
}
