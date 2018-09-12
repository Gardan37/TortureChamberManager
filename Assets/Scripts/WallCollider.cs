using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    public GameObject player;
    public string wallName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            player.SendMessage("WallHit", wallName);
        }

    }

}
