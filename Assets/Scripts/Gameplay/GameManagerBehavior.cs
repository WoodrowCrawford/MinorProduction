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


    //A value that keeps track of the current score
    [SerializeField]
    public static int score = 0;

    //A value that keeps track of the current score
    [SerializeField]
    public static int wave = 1;


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

    

    //What happens when the player clicks start on the main menu
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        score = 0;
        wave = 1;
    }

    //What happens when the game restarts 
    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
        score = 0;
        wave = 1;
    }

    //What happens when the game quits
    public void QuitGame()
    {
        Application.Quit();
    }


    private void Start()
    {
        //Sets the score to be equal to zero when the game is started
        score = 0;

        //Sets the player health to be equal to 3 by default
        _playerHealth.Health = 3;

        //Sets the current wave to be 1
        wave = 1;
    }

    //Update is called once per frame
    void Update()
    {
        //If the player health is less than or greater than 0, then the game over screen will appear

        if (GameOver == true)
        {
            _gameOver = true;
        }

        if (score == (wave * 5))
        {
            wave++;
        }
      
        _gameOver = _playerHealth.Health <= 0;

        _gameOverScreen.SetActive(_gameOver);
        
    }
}
