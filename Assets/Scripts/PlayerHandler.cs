using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHandler : MonoBehaviour
{
    public float impluseForce = 10.0f;

    private Rigidbody2D player;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void PushLeft()
    {
        player.AddForce(new Vector2(-impluseForce, 0.0f));
    }

    void PushRight()
    {
        player.AddForce(new Vector2(impluseForce, 0.0f));
    }

    void BottomReached()
    {
        player.transform.position = new Vector3(player.transform.position.x, 0.0f);
    }
}
