using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{

    public static GameControler Instance;
    public static int Points {get; private set;}
    public static bool GameStarted {get; private set;}
    public static float Timer {get; private set;}
    public static float Records {get; private set;}
    public GameObject pauseWin;
    public GameObject pauseLose;
    private float timer = 0f;
    private float bestTime;
    private bool timerIsRunning = false;

    [SerializeField]
    private TextMeshProUGUI gameResult;
    [SerializeField]
    private TextMeshProUGUI pointsText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI bestTimePanel;
   
   

    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartGame();
        
       
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            timer += Time.deltaTime;
            DisplayTime(timer);
        }
    }
    public void StartGame()
    {
        gameResult.text = "";
        SetPoints(0);
        GameStarted = true;
        RestartTimer();
        Field.Instance.GenerateField();
        StartTime();
        pauseLose.SetActive(false);
        pauseWin.SetActive(false);
        DisplayBestTime();
    }
    public void Win()
    {
        GameStarted = false;
        pauseWin.SetActive(true);
        StopTime();
    }

    public void Lose()
    {
        GameStarted = false;
        pauseLose.SetActive(true);
        StopTimeLose();
       
    }

    public void AddPoints(int points)
    {
        SetPoints(Points + points);
    }

    public void SetPoints(int points)
    {
        Points = points;
        pointsText.text = Points.ToString();
    }

    public void RestartTimer()
    {
       timer = 0f;
       timerIsRunning = true;
       DisplayTime(timer);
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

    public void CheckBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("Best time", float.MaxValue);
        if (timer < bestTime)
        {
            PlayerPrefs.SetFloat("Best time", timer);
            PlayerPrefs.Save();
            DisplayBestTime();
        }
    }

    public void DisplayNewBestNime()
    {

    }

    public void DisplayBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("Best time", float.MaxValue);
        if (bestTime != float.MaxValue)
        {
            float minutes = Mathf.FloorToInt(bestTime / 60);
            float seconds = Mathf.FloorToInt(bestTime % 60);
            bestTimePanel.text = string.Format("Best time: {0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            bestTimePanel.text = "No Best Time";
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartTime()
    {
        timerIsRunning = true;
    }

    public void StopTime()
    {
        timerIsRunning = false;
        CheckBestTime();
    }

    public void StopTimeLose()
    {
        timerIsRunning = false;
        
    }
   
}
