using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    private int _score;
    public Text scoreText;



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

    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
