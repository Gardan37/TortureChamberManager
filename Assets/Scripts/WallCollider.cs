using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    public GameObject player;
    public string wallName;
    AudioSource audioData;

 void Start()
    {
        audioData = GetComponent<AudioSource>();
    //    audioData.Play(0);
    //    Debug.Log("started");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
        	audioData.Play(0);

            player.SendMessage("WallHit", wallName);
        }

    }

}
