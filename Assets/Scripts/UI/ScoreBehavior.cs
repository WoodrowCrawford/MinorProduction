using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    [SerializeField]
    public int scoreValue = 0;

    [SerializeField]
    public Text scoreText;


    //Makes a reference of the score value
    public int Score
    {
        get
        {
            return scoreValue;
        }
        set
        {
            scoreValue = value;
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

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shows "Score: #" on the screen
        scoreText.text = "Score: " + scoreValue;
    }

    

   
}
