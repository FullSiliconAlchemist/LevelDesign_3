using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.8f;
    public float slowDownLength = 2f;
    public bool bulletTime = false;
    private AudioSource music;

    private void Start()
    {
        music = FindObjectOfType<AudioManager>().GetSound("Music").source;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        float replayFrom = music.time;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (music.pitch != 0.5f)
            {
                music.pitch = 0.3f;
                music.volume = 0.1f;
                music.time = replayFrom;
                music.spatialize = true;
            }

            this.BulletTime();
            this.bulletTime = true;
        }
        else
        {
            if (music.pitch != 1f)
            {
                music.pitch = 1f;
                music.volume = 0.2f;
                music.time = replayFrom;
                music.spatialize = false;
            }

            Time.timeScale += slowDownLength * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            this.bulletTime = false;
        }
    }

    public void BulletTime()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
