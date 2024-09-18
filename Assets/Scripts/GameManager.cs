using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float Timer;
    [SerializeField] TextMeshProUGUI TimerDisplay;
    
    void Start()
    {
        Timer = 120;
    }


    void Update()
    {
        float minutes = Mathf.FloorToInt(Timer / 60f);
        float seconds = Mathf.FloorToInt(Timer - minutes * 60);
        string displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        TimerDisplay.text = "Time till HUNT: " + displayTime;
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 0;
            TimerDisplay.text = "IT KNOW YOUR LOCATION!";

        }
    }
}
