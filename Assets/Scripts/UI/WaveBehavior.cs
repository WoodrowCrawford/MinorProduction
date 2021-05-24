using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBehavior : MonoBehaviour
{
    [SerializeField]
    private int _wave;

    [SerializeField]
    public Text waveText;


    //Makes a reference of the wave value
    public int Wave
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

    // Update is called once per frame
    void Update()
    {

    }

}