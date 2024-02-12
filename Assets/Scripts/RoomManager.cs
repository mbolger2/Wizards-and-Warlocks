using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomManager : MonoBehaviour
{
    // use lists of tilemaps for the doors then iterate through with for loop to set false and active, 
    // this takes care of door opening combos
    public GameObject doorsShut;

    public GameObject doorsOpen;

    public int enemyCount;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyCount--;

            if (enemyCount == 0)
            {
                doorsShut.SetActive(false);
                doorsOpen.SetActive(true);
            }
        }
    }
}
