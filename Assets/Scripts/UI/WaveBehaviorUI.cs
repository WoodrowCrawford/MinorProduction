using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBehaviorUI : MonoBehaviour
{
    [SerializeField]
    public Text waveText;

    private GameManagerBehavior _gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = GetComponent<GameManagerBehavior>();
        waveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Wave: " + GameManagerBehavior.wave;
    }
}
