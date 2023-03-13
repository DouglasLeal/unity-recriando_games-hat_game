using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if(transform.position.y < -11)
        {
            DestruirObjeto();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            gameController.Pontuar();
            DestruirObjeto();
        }
    }

    private void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
