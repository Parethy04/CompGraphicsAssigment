using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private float Timer;
    [SerializeField] TextMeshProUGUI TimerDisplay;
    [SerializeField] Enemy monsterAI;
    
    void Start()
    {
        Timer = 240;
    }


    void Update()
    {
        float minutes = Mathf.FloorToInt(Timer / 60f);
        float seconds = Mathf.FloorToInt(Timer - minutes * 60);
        string displayTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        TimerDisplay.text = "Time till the HUNT: " + displayTime;
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 0;
            TimerDisplay.text = "IT KNOWS YOUR LOCATION!";
            monsterAI._IsHunting = true;
        }
    }
}
