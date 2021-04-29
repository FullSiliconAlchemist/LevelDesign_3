using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameEnd = false;
    public GameObject winScreen;
    public int delay = 2;
    public void EndGame ()
    {
        if (GameEnd == false)
        {
            GameEnd = true;
            Invoke("Restart", delay);
        }
    }

    public void Win ()
    {
        winScreen.SetActive(true);
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
