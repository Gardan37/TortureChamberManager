using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHandler : MonoBehaviour
{
    public float impluseForce = 10.0f;
    private int scorePerHit = 100;

    public Text hitpointText;
    public Text scoreText;

    private int hitpoints = 10;
    private int score = 0;
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
        PlayerHit(-1);
    }

    void PlayerHit(int hitforce)
    {
        hitpoints += hitforce;
        hitpointText.text = "Hitpoints: " + hitpoints;
        score += scorePerHit;
        scoreText.text = "Score: " + score;

    }
}
