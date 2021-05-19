using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public delegate void GameEvent();
public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private static bool _gameOver = false;

    //The player's current score
    [SerializeField]
    private float _score;

    //The current wave the player is on
    [SerializeField]
    private float _wave;

    //What happens when the the game is over
    public static GameEvent onGameOver;

    //Gets a reference of the player health for the game manager
    [SerializeField]
    private HealthBehavior _playerHealth;


    //Gets a reference of the enemy health for the game manager.
    //NOTE: IF THIS DOES NOT HAVE A PURPOSE, CAN BE REMOVED.
    [SerializeField]
    private HealthBehavior _enemyHealth;

    //The game over screen
    [SerializeField]
    private GameObject _gameOverScreen;

   
    //Gets a reference of the gameover variable
    public static bool GameOver
    {
        get
        {
            return _gameOver;
        }
    }


    public float Score
    {
        get
        {
            return _score;
        }
    }

    public float Wave
    {
        get
        {
            return _wave;
        }
    }

    //What happens when the game restarts 
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    //What happens when the game quits
    public void QuitGame()
    {
        Application.Quit();
    }


    private void Start()
    {
        //Sets the score to be equal to zero when the game is started
        _score = 0;
        
        //Sets the current wave to be 1
        _wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //If the player health is less than or greater than 0, then the game over screen will appear
        //NOTE: AS OF THIS EDIT, THE GAME OVER SCREEN DOES NOT EXIST YET.
        _gameOver = _playerHealth.Health <= 0;

        _gameOverScreen.SetActive(_gameOver);
    }
}
