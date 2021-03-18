using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Sami Kaski 
    public float jumpPower = 10.0f;
    Rigidbody2D myRigidbody;
    bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;





    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;



    }

    public void GameOver()
    {
        isGameOver = true;
        Invoke("ShowOverPanel", 1.0f);




    }

    void ShowOverPanel()
    {
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            IncrementScore();
            Destroy(other.gameObject);
        }
    }


    void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }

        if (other.collider.tag == "Enemy")
        {
            GameOver();
        }
    }

   

    

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.gravityScale * 20.0f));


            if (transform.position.x < posX)
            {
                GameOver();
            }

        }

        void Update()
        {


        }

          

        

        

        
    }
}