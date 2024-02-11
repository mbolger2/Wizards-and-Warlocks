using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingAILogic : MonoBehaviour
{
    // The target of the enemy
    public GameObject player;

    // Pathing waypoints
    public GameObject waypoint1;
    public GameObject waypoint2;

    // Speed of the enemy
    public float speed;


    private float distance;

    // For waypoint swapping
    private Transform lastWaypoint;

    // The axe getting thrown
    public GameObject throwingAxe;
    public Transform axeTransform;

    private float timer;
    public bool canFire;
    private float timeBetweenFiring = 3;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypoint = waypoint1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Shooting speed logic
        if (canFire == false)
        {
            timer += Time.deltaTime;

            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        // The player is within 10 units
        if (player.transform.position.x > transform.position.x - 10 &&
            player.transform.position.x < transform.position.x + 10 &&
            player.transform.position.y > transform.position.y - 10 &&
            player.transform.position.y < transform.position.y + 10)
        {
            if (canFire)
            {
                Instantiate(throwingAxe, axeTransform.position, Quaternion.identity);
                canFire = false;
            }
        }

        // If the player comes within 15 units of the enemy
        else if (player.transform.position.x > transform.position.x - 15 &&
            player.transform.position.x < transform.position.x + 15 &&
            player.transform.position.y > transform.position.y - 15 &&
            player.transform.position.y < transform.position.y + 15)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        // Idle pathing when player is not near
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



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
