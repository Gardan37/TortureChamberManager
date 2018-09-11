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
    public GameObject sceneSwitcher;

    private int level = 1;
    private int maxhitpoints = 100;
    private int hitpoints;
    private int score = 0;
    private Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        level = 1;
        hitpoints = maxhitpoints;
        UpdateScore();
    }
    private float timer = 0.0f;

    private void Update()
    {
        GameOverCheck();

        timer += Time.deltaTime;
        if (timer > 1)
        {
            timer--;
            if (hitpoints < maxhitpoints)
            {
                hitpoints++;
            }
        }
        UpdateScore();
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
        level++; 
        PlayerHit(-1*level, scorePerHit); // temporary
        
    }

    void PlayerHit(int hitforce, int hitscore)
    {
        hitpoints += hitforce;
        score += hitscore * level;
    }

    private void UpdateScore()
    {
        hitpointText.text = "Hitpoints: " + hitpoints;
        scoreText.text = "Score: " + score;
    }

    void GameOverCheck()
    {
        if (hitpoints > 0)
        {
            return;
        }
        sceneSwitcher.GetComponent<SimpleSceneSwitch>().OpenStartScene();
    }
}
