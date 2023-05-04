using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{

    public GameObject pauseScreenPanel;

    bool isPaused = false;
    
    void Start()
    {
       pauseScreenPanel.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f;
                pauseScreenPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseScreenPanel.SetActive(false);
            }
        }   
    }
    

    public void ExitLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");

    }

}
