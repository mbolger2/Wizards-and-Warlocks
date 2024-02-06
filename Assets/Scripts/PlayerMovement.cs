using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed of the player
    public float speed;

     // Update is called once per frame
    void Update()
    {
        float xMov, yMov;

        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        Vector3 motion = new Vector3(xMov, yMov, 0) * speed * Time.deltaTime;
        
        Vector3 finalPos = transform.position + motion;

        transform.position = finalPos;
    }
}
