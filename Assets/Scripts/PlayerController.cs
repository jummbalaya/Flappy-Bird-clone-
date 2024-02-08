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


    Rigidbody2D rb;
    int score;
    int highScore;

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
    }

    void Jump()
    {
        audio.clip = wingSound;
        rb.velocity = new Vector2(rb.velocity.x, pushForce);
        audio.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "ScorePoint")
        {
            GameOver();
        }
            
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        audio.clip = pointSound;
        audio.Play();
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
}
