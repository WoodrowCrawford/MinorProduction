using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBehavior : MonoBehaviour
{
    private int _wave;
    public Text waveText;



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

    // Start is called before the first frame update
    void Start()
    {

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