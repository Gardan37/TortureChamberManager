using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    public int hitForce = 0;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            player.SendMessage("PlayerHit", hitForce);
        }

    }
}
