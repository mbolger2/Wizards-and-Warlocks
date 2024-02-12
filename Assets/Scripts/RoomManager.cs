using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomManager : MonoBehaviour
{
    // use lists of tilemaps for the doors then iterate through with for loop to set false and active, 
    // this takes care of door opening combos
    public List<GameObject> doorsShut;
    public List<GameObject> doorsOpen;
    //public GameObject doorsShut;

    //public GameObject doorsOpen;

    public int enemyCount;

    void Start()
    {
        for (int i = 0; i < doorsShut.Count; i++)
        {
            doorsShut[i].SetActive(true);
        }

        for (int i = 0;i < doorsOpen.Count;i++)
        {
            doorsOpen[i].SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyCount--;

            if (enemyCount == 0)
            {
                for (int i = 0; i < doorsShut.Count; i++)
                {
                    doorsShut[i].SetActive(false);
                }

                for (int i = 0; i < doorsOpen.Count; i++)
                {
                    doorsOpen[i].SetActive(true);
                }
            }
        }
    }
}
