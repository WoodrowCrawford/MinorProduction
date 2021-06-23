using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [Tooltip("The enemy that will be spawned.")]
    [SerializeField]
    private GameObject _enemy;
    [Tooltip("The boss that will be spawned during boss waves.")]
    [SerializeField]
    private GameObject _bossEnemy;
    [Tooltip("The amount of enemies in this wave.")]
    private int _waveLength;
    [Tooltip("The set time between spawns.")]
    [SerializeField]
    private float _spawnTimer;
    [Tooltip("While this is true, enemies spawn.")]
    [SerializeField]
    private bool _spawnEnemy;
    [Tooltip("The minimum X position for the enemy.")]
    [SerializeField]
    private Transform _minX;
    [Tooltip("The maximum X position for the enemy.")]
    [SerializeField]
    private Transform _maxX;
    [Tooltip("The wave that the player is on.")]
    [SerializeField]
    private WaveBehavior _wave;
    [Tooltip("The GameManager.")]
    [SerializeField]
    private GameManagerBehavior _gameManager;
    private int _waveNumber;

    void Awake()
    {
        _gameManager = GetComponent<GameManagerBehavior>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //On start, set waveNumber to be the current wave
        _waveNumber = _wave.Wave;
        //set waveLength to be the current wave times 5
        _waveLength = GameManagerBehavior.wave * 4;

        //Starts Coroutine and spawns objects
        StartCoroutine(SpawnObjects());
    }
    private void Update()
    {
        SpawnObjects();
    }

    //Spawns enemies while _spawnEnemy is true
    public IEnumerator SpawnObjects()
    {
        while(_spawnEnemy == true)
        {
            //if the wave is divisible by 5, spawn boss wave
            if ((_waveLength % 5) == 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    //Spawns boss wave
                    GameObject spawnBoss = Instantiate(_bossEnemy, transform.position, new Quaternion());
                }
            }

            //if the wave is not divisible by 5, start normal wave
            if ((_waveLength % 5) != 0)
            {
                for (int i = 0; i < _waveLength; i++)
                {
                    //Spawns an enemy
                    GameObject spawnEnemy = Instantiate(_enemy, transform.position, new Quaternion());
                    //Prevents enemies from spawning until the timer is up
                    yield return new WaitForSeconds(_spawnTimer);
                }

            }

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                GameManagerBehavior.wave++;
                SpawnObjects();
            }
        }
        
    }
}
