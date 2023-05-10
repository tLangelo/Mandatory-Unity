using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioClip goalSound;
    private AudioSource _audioSource;

    public Transform ball;
    public Vector3 resetPos;
    public Rigidbody ballRigidbody;

    public int scoreToWin = 3;
    private int _score = 0;
    
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _score++;
            _audioSource.PlayOneShot(goalSound);
            Debug.Log("GOAAAAAAL");

            if (_score >= scoreToWin)
            {
                if (SceneManager.GetActiveScene().buildIndex >= 3)
                    SceneManager.LoadScene(0);
                else
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            
            // Add score
            ScoreManager.Instance.AddScore(1);

            // Update score text
            //ScoreManager.Instance.scoreText.text = "Score: " + ScoreManager.Instance.score;
            
            ball.position = resetPos;
            
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
