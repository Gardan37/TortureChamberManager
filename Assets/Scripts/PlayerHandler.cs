using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHandler : MonoBehaviour
{
    public float impulseForce = 10.0f;
    private int scorePerHit = 100;

    public Text hitpointText;
    public Text scoreText;
    public GameObject sceneSwitcher;
    public bool rotationEnabled = false;

    private int level = 1;
    private int maxhitpoints = 10;
    private int hitpoints;
    private int score = 0;
    private Rigidbody2D player;
    private float rotationSpeed = 0.0f;

    private float timer = 0.0f;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        level = 1;
        hitpoints = maxhitpoints;
        UpdateScore();
    }

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

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < 320)
            {
                player.AddForce(new Vector2(-impulseForce, 0.0f));
            }
            else if (Input.mousePosition.x > 320)
            {
                player.AddForce(new Vector2(impulseForce, 0.0f));
            }
        }
    }


    private void FixedUpdate()
    {
        if (rotationEnabled)
        {
            player.MoveRotation(player.rotation + rotationSpeed * Time.fixedDeltaTime);
        }
    }

    void BottomReached()
    {
        player.transform.position = new Vector3(player.transform.position.x, 0.0f);

        if (hitpoints == maxhitpoints)
        {
            if (level > 1)
            {
                level--;
            }
        }
        else
        {
            level++;
        }
    }

    void PlayerHit(int hitforce)
    {
        Debug.Log(hitforce);
        hitpoints -= hitforce;
        score += hitforce * scorePerHit * level;
        player.velocity = new Vector2(player.velocity.x, 0.0f);
    }

    void WallHit(string wallName)
    {
        score += scorePerHit * level;

        if (player.velocity.x > 0 && wallName == "Right")
        {
            player.velocity = new Vector2(-player.velocity.x/2.0f, player.velocity.y);
            rotationSpeed = 50.0f;
            
        }
        else if (player.velocity.x < 0 && wallName == "Left")
        {
            player.velocity = new Vector2(-player.velocity.x/2.0f, player.velocity.y);
            rotationSpeed = -50.0f;
        }

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
