using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    [SerializeField]
    private int _score;

    [SerializeField]
    public Text scoreText;


    //Makes a reference of the score value
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }


    //Sets the score value to equal 0
    public void RestartScore()
    {
        Score = 0;
    }
    //Adds points to the score with a given value
    public void AddScore(int value)
    {
        Score += value;
        scoreText.text = Score.ToString();
    }

    //A score multiplier that can be used for a powerup.
    public void ScoreMultiplier(int value)
    {
        Score *= value;
    }

    // Update is called once per frame
    void Update()
    {
        //For this, I want the score counter to increase when the enemy has been defeated
    }
}
