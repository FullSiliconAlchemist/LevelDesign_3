using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pauseButton, pausePanel;
    public bool paused = false;

    public void Start() 
    {
        OnResume();

    }

    public void OnPause()
        {
            pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0;
            paused = true;
        }
    
    public void OnResume()
        {
            pausePanel.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1;
            paused = false;
        }
    
}
