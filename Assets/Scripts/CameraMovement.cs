using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The player
    public Transform player;

    // Camera Smoothing
    private Vector3 offset = new Vector3 (0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraTargetPosition =
            new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10f);

        transform.position =
            Vector3.SmoothDamp(transform.position, cameraTargetPosition,
            ref velocity, smoothTime);
    }
}
