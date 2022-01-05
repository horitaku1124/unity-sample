using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private Text timeText;
    private DateTime startTime;
    private bool playingGame;

    // Start is called before the first frame update
    void Start()
    {
        GameObject timeTextObj = GameObject.Find("Time");
        timeText = timeTextObj.GetComponent<Text>();
        startTime = DateTime.Now;
        playingGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playingGame) {
            timeText.text = String.Format("{0:F1}", DateTime.Now.Subtract(startTime).TotalSeconds) + "秒";
        }
    }

    public void stopGame()
    {
        playingGame = false;
    }

    public bool isPlayingGame()
    {
        return playingGame;
    }
}
