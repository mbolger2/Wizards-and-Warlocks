using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour
{
   public int enemyCount;

    public GameObject closedDoors;
    public GameObject OpenDoors;

    void Start()
    {
        closedDoors.SetActive(true); 
        OpenDoors.SetActive(false);
    }

    void Update()
    {
        if (enemyCount == 0)
        {
            closedDoors.SetActive(false);
            OpenDoors.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyCount--;
        }
    }
}
