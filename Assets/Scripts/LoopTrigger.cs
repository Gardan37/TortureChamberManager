using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTrigger : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.SendMessage("BottomReached");
        }

    }
}
