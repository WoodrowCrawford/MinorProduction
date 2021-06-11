using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviorUI : MonoBehaviour
{

    [SerializeField]
    public Text scoreText;

    private GameManagerBehavior _gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = GetComponent<GameManagerBehavior>();
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManagerBehavior.score;
    }
}
