using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontroller : MonoBehaviour
{

    // Variables
    float timeRemaining = 120,minutesRemaining,secondsRemaining;
    public TextMeshProUGUI timertext,score1text,score2text;
    public GameObject Football;
    ScoreSystem scoresysscr;

    private void Start() {
        scoresysscr = Football.GetComponent<ScoreSystem>();
    }

    private void Update() {
        // Call the timer method 
        Timer();

        // Telling the score
        score1text.text = string.Format("Team 1 : {0}",scoresysscr.score1);
        score2text.text = string.Format("Team 2 : {0}",scoresysscr.score2);

    }
    // Timer method
    void Timer()
    {
        timeRemaining -= Time.deltaTime;
        minutesRemaining = Mathf.FloorToInt(timeRemaining/60);
        secondsRemaining = Mathf.FloorToInt(timeRemaining%60);
        timertext.text = string.Format("{0:00}:{1:00}",minutesRemaining,secondsRemaining);
    }
}
