using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    private float timer = 0f;
    private bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public static TimerControl Instance;

    
    void Update()
    { 
        if (timerIsRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "" + Mathf.Floor(timer).ToString(); 
        }
    }

    public void StartTime()
    {
        timerIsRunning = true;
    }

    public void StopTime()
    {
        timerIsRunning = false;
    }
}
