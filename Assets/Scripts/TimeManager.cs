using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.8f;
    public float slowDownLength = 2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            this.BulletTime();
        }
        else
        {
            Time.timeScale += (slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        //Debug.Log(Time.timeScale);
    }

    public void BulletTime()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
