using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text scoreDisplay;
    [SerializeField] private Text timeDisplay;
    [SerializeField] private Text livesDisplay;
    [SerializeField] private Text turnDisplay;

    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text livesLabel;
    [SerializeField] private Text turnLabel;

    [SerializeField] private Camera gameCamera;

    // Update is called once per frame
    void Update()
    {
        DataDisplay();
    }

    private void DataDisplay()
    {
        timeDisplay.text = Auxiliary.GetTimeString(Time.timeSinceLevelLoad);
        scoreDisplay.text = Game.score.ToString("00");
        turnDisplay.text = Game.turn.ToString("00");
        livesDisplay.text = Game.live.ToString("00");

        if(CustomColor.CalcLuminance(gameCamera.backgroundColor) >= 0.5)
        {
            ChangeFontColor(Color.black);
        }
        else
        {
            ChangeFontColor(Color.white);
        }
    }

    private void ChangeFontColor(Color color)
    {
        scoreDisplay.color = color;
        timeDisplay.color = color;
        livesDisplay.color = color;
        turnDisplay.color = color;

        scoreLabel.color = color;
        timeLabel.color = color;
        livesLabel.color = color;
        turnLabel.color = color;
    }
}
