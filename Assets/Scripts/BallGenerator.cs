using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private float topDistance;
    [SerializeField]
    private float lateralMargin;

    private Vector2 screenWidth;

    private GameController gameController;


    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        InvokeRepeating("GenerateInvoke", 2, Random.Range(1, 3));
    }

    private void Initialize()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));
        Vector2 heightPosition = new Vector2(transform.position.x, Camera.main.orthographicSize + topDistance);
        transform.position = heightPosition;
    }

    private void GenerateInvoke()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        if (gameController.gameStarted)
        {
            yield return new WaitForSeconds(0);
            transform.position = new Vector2(Random.Range(-screenWidth.x + lateralMargin, screenWidth.x - lateralMargin), transform.position.y);
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
