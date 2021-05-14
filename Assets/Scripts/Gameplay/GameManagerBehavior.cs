using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public delegate void GameEvent();
public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    private static bool _gameover = false;

    //The player's current score
    [SerializeField]
    private float _score;

    //What happens when the the game is over
    public static GameEvent onGameOver;

    //Gets a reference of the player health for the game manager
    [SerializeField]
    private HealthBehavior _playerHealth;


    //Gets a reference of the enemy health for the game manager
    [SerializeField]
    private HealthBehavior _enemyHealth;

    //The game over screen
    [SerializeField]
    private GameObject _gameOverScreen;

   
    public static bool GameOver
    {
        get
        {
            return _gameover;
        }
    }


    //What happens when the game restarts 
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        //Sets the score to be equal to zero when the game is started
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If the player health is less than or greater than 0, then game over will be set to false
        _gameover = _playerHealth.Health <= 0;
    }
}
