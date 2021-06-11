using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public delegate void GameEvent();
public class GameManagerBehavior : MonoBehaviour
{
   
    [SerializeField]
    private static bool _gameOver = false;

    //What happens when the the game is over
    public static GameEvent onGameOver;


    //The game over screen
    [SerializeField]
    private GameObject _gameOverScreen;


    //Gets a reference of the player health for the game manager
    [SerializeField]
    private HealthBehavior _playerHealth;


    //The player's current score
    //Uses the score behavior as a reference
    [SerializeField]
    private ScoreBehavior _score;


    //The current wave the player is in
    //Uses the wave behavior as a reference
    [SerializeField]
    private WaveBehavior _wave;


    //Gets a reference of the enemy health for the game manager.
    //NOTE: IF THIS DOES NOT HAVE A PURPOSE, CAN BE REMOVED.
    [SerializeField]
    private HealthBehavior _enemyHealth;


    //Gets a reference of the gameover variable
    public static bool GameOver
    {
        get
        {
            return _gameOver;
        }
        
    }


    public WaveBehavior Wave
    {
        get
        {
            return _wave;
        }
        set
        {
            _wave = value;
        }
    }


    public ScoreBehavior Score
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

    //What happens when the player clicks start on the main menu
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    //What happens when the game restarts 
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    //What happens when the game quits
    public void QuitGame()
    {
        Application.Quit();
    }


    private void Start()
    {
        //Sets the score to be equal to zero when the game is started
        Score.RestartScore();
        _playerHealth.Health = 3;

        //Sets the current wave to be 1
        Wave.RestartWave();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player health is less than or greater than 0, then the game over screen will appear
        //NOTE: AS OF THIS EDIT, THE GAME OVER SCREEN DOES NOT EXIST YET.
        if(GameOver == true)
        {
            _gameOver = true;
        }
      
        _gameOver = _playerHealth.Health <= 0;

        _gameOverScreen.SetActive(_gameOver);
        
       
        
    }
}
