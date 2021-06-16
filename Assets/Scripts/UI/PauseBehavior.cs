using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseBehavior : MonoBehaviour
{

    public GameObject PauseScreen;

    [SerializeField]
    public bool GamePaused;

    private PlayerControls _player;

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
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            GamePaused = !GamePaused;
        }

        if (GamePaused)
        {
            Time.timeScale = 0.000001f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
