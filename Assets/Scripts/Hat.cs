using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float minX;
    private float maxX;

    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float maxDistance;


    private void Start()
    {
        SetMinAndMaxX();
    }

    void Update()
    {
        SetPlayerPosition();
        DragTouch();
    }

    private void DragTouch()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0, 0);
        }
    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0, 0));
        maxX = bounds.x - maxDistance;
        minX = -bounds.x + minDistance;
    }

    private void SetPlayerPosition()
    {
        if(transform.position.x < minX) transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.x > maxX) transform.position = new Vector2(maxX, transform.position.y);
    }
}
