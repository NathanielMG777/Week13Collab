using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private float horizontalScreenLimit;
    private float verticalScreenLimit;

    public GameObject explosion;
    public GameObject bullet;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6.5f;
        horizontalScreenLimit = 11.15f;
        verticalScreenLimit = 7.5f;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);

        //if my x position is bigger than 9.5f I am outside the screen from the right
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y > 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, 0);
        }

        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseALife()
    {
        //lives = lives - 1;
        //lives -= 1;
        lives--;
        if (lives == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().LifeCounter(-1);
    }
}
