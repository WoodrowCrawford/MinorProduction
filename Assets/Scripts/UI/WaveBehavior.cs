using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBehavior : MonoBehaviour
{
    //The current wave that the player is on
    [SerializeField]
    private int wave;

    [SerializeField]
    private Text waveText;


    //Makes a reference of the wave value
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
        }
    }


    //Sets the wave value to equal 1
    public void RestartWave()
    {
        Wave = 1;
    }
    //Makes the wave value go up according to the value given
    public void SetWave(int value)
    {
        Wave += value;
        waveText.text = Wave.ToString();
    }

    private void Start()
    {
        waveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shows "Wave: #" on the screen
        //waveText.text = "Wave: " + wave;
    }

}