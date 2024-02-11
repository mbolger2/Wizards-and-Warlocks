using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomLogic : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();

    public TextMeshProUGUI enemiesLeft;
    public int enemiesAlive;

    void Update()
    {
        enemiesAlive = Enemies.Count;

        enemiesLeft.text = enemiesAlive.ToString();
    }
}
