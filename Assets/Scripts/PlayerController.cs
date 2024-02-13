using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    // Adjust this to control the jump height
    [SerializeField] float pushForce = 5f;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip wingSound;
    [SerializeField] AudioClip dieSound;
    [SerializeField] AudioClip pointSound;
    [SerializeField] float rotationSpeed = 5f;



    Rigidbody2D rb;
    int score;
    int highScore;
    bool isBuffedUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        scoreText.text = score.ToString();
        highScoreText.text = "Best score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
        {
            GameOver();
        }
        //sprite.localRotation = Quaternion.Euler(0, 0, rb.velocity.y);
    }

    void FixedUpdate()
    {
        RotatePlayer();
    }

    void Jump()
    {
        audio.clip = wingSound;
        rb.velocity = new Vector2(rb.velocity.x, pushForce);
        audio.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            GameOver();
        }
        if (collision.gameObject.tag == "BuffUp")
        {
            isBuffedUp = true;
            Destroy(collision.gameObject);
        }
    }

    public void IncrementScore()
    {
        if (isBuffedUp)
        {
            score += 5;
        }
        else
        {
            score++;
        }
        scoreText.text = score.ToString();
        audio.clip = pointSound;
        audio.Play();

        isBuffedUp = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScorePoint")
        {
            IncrementScore();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        audio.clip = dieSound;
        audio.Play();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void RotatePlayer()
    {
        // Check if the player is jumping or falling
        if (rb.velocity.y > 0) // If player is jumping
        {
            transform.rotation = Quaternion.Euler(0, 0, rotationSpeed);
        }
        else if (rb.velocity.y < 0) // If player is falling
        {
            transform.rotation = Quaternion.Euler(0, 0, -rotationSpeed);
        }
        else // If player is not jumping or falling, reset rotation
        {
            transform.rotation = Quaternion.identity;
        }
    }

}
