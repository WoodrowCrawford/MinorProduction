using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    //The main menu screen
    [SerializeField]
    private GameObject _mainMenuScreen;


    //What happens when the player clicks start on the main menu
    public void StartGame()
    {
        SceneManager.LoadScene("UITestingScene");
    }

    //What happens when the game quits
    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
