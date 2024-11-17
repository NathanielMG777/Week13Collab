using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject cloud;
    public GameObject coin;
    private int score;
    private int lives;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 5f, 5f);
        InvokeRepeating("CreateCoin", 1f, 4f);
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;

        lives = 3;
        livesText.text = "Lives " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    void CreateEnemy2()
    {
        Instantiate(enemy2, new Vector3(-11.5f, Random.Range(-5.25f, 1f), 0), Quaternion.Euler(0, 0, -90));
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }

    public void LifeCounter(int loseLife)
    {
        lives = lives + loseLife;
        livesText.text = "Lives: " + lives;
    }

    public void EarnScore(int howMuch) 
    {  
        score = score + howMuch;
        scoreText.text = "Score: " + score;
    }

}
