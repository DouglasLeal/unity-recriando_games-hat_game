using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;
    public float currentTime;

    [SerializeField]
    private float startTime;

    public bool gameStarted = false;

    [SerializeField]
    private GameObject panelMainMenu;

    private void Start()
    {
        currentTime = startTime;

        gameStarted = true;
    }

    private void Update()
    {
        CountDownTime();
    }

    public void Pontuar()
    {
        score++;
    }

    public void CountDownTime()
    {
        if(currentTime > 0)
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
        gameStarted = true;
        panelMainMenu.SetActive(false);
    }
}
