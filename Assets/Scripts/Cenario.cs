using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Vector3 scaleTemp = GetComponent<Transform>().transform.localScale;

        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        float heightCamera = Camera.main.orthographicSize * 2;
        float widthWorld = heightCamera / Screen.height * Screen.width;

        scaleTemp.x = widthWorld / width;
        scaleTemp.y = heightCamera / height;

        transform.localScale = scaleTemp;
    }
}
