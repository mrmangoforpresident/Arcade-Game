using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    public Vector3 reSpawn = new Vector3(-3, 3, 0);
    //if touched by Player, reset Player to old position
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = reSpawn;
        }
    }
}
