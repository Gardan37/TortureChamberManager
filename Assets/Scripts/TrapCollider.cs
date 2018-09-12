using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    public int hitForce = 0;

    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("PlayerHit", hitForce);
        }
    }
}
