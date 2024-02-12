using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestruction : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Spell2"))
        {
            Destroy(this.gameObject);
        }

        else if (other.gameObject.CompareTag("EnemyAxe"))
        {
            Destroy(this.gameObject);
        }
    }
}
