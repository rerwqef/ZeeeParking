using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float time;
    public Text timertext;
    public float max;
    GameOver gameOver;
    void Start()
    {
        time = max;
        gameOver = GameObject.FindAnyObjectByType<GameOver>();
    }

    void Update()
    {
        // Decrease time by deltaTime
        time -= Time.deltaTime;

        // Ensure time doesn't go below 0
        time = Mathf.Max(time, 0f);

        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        // Update the UI text to display minutes and seconds
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Check if time is up
        if (time <= 0)
        {
            // Perform actions when time is up
            Debug.Log("Time's up!");
            
            gameOver.gameover();
            // Add your code here for when the time is up
        }
    }
}