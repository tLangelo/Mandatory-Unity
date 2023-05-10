using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public float speed = 5f;
    public float leftBoundary = -4f;
    public float rightBoundary = 4f;

    private float direction = 1f;

    void Update()
    {
        Vector3 newPosition = transform.position + new Vector3(speed * direction * Time.deltaTime, 0f, 0f);

        if (newPosition.x < leftBoundary || newPosition.x > rightBoundary)
        {
            direction = -direction;
        }
        else
        {
            transform.position = newPosition;
        }
    }
}

