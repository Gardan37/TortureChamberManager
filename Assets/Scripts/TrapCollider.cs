using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    public int hitForce = 0;
    AudioSource audioData;

    public GameObject player;
 void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("PlayerHit", hitForce);
            audioData.Play(0);

        }
    }
}
