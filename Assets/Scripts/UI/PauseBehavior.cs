using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{

    public GameObject PauseScreen;

    bool GamePaused;

    //Pauses the game
    public void PauseGame()
    {
        GamePaused = true;
        PauseScreen.SetActive(true);
    }

    //Resumes the game
    public void ResumeGame()
    {
        GamePaused = false;
        PauseScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
