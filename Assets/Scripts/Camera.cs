using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // the player object
    public float distance = 5.0f; // distance from player
    public float height = 2.0f; // height above player
    public float smoothSpeed = 0.125f; // smoothing factor

    private Vector3 offset; // initial offset between camera and player

    void Start()
    {
        // Calculate the initial offset between camera and player
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = target.position.y + height;

        // Move the camera smoothly towards the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}
