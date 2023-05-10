using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenuCanvas;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Stop();
            }
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Stop()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}