using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILogic : MonoBehaviour
{
    public GameObject player;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public float speed;
    private float distance;
    private Transform lastWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypoint = waypoint1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.transform.position.x > transform.position.x - 10 &&
            player.transform.position.x < transform.position.x + 10 &&
            player.transform.position.y > transform.position.y - 10 &&
            player.transform.position.y < transform.position.y + 10)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        else
        {
            if (transform.position == waypoint1.transform.position)
            {
                lastWaypoint = waypoint1.transform;
            }
            else if (transform.position == waypoint2.transform.position)
            { 
                lastWaypoint = waypoint2.transform; 
            }

            if (lastWaypoint.transform.position == waypoint1.transform.position)
            {
                distance = Vector2.Distance(transform.position, waypoint2.transform.position);
                Vector2 direction = waypoint2.transform.position - transform.position;

                transform.position = Vector2.MoveTowards(this.transform.position, waypoint2.transform.position, speed * Time.deltaTime);
            }
            else
            {
                distance = Vector2.Distance(transform.position, waypoint1.transform.position);
                Vector2 direction = waypoint1.transform.position - transform.position;

                transform.position = Vector2.MoveTowards(this.transform.position, waypoint1.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
