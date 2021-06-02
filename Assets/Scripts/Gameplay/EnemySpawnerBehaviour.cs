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
    [Tooltip("The max z that the enemy can go.")]
    [SerializeField]
    private Transform _zMin;
    [Tooltip("The wave that the player is on.")]
    [SerializeField]
    private WaveBehavior _wave;
    private int _waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        _waveNumber = _wave.Wave;
        _waveLength = _waveNumber * 5;
        StartCoroutine(SpawnObjects());
    }

    //Spawns enemies while _spawnEnemy is true
    public IEnumerator SpawnObjects()
    {
        if ((_waveNumber % 5) == 0)
        {
            for (int i = 0; i < 1; i++)
            {
                //Spawns boss wave
                GameObject spawnBoss = Instantiate(_bossEnemy, transform.position, new Quaternion());
            }
        }

        if((_waveNumber % 5) != 0)
        {
            for (int i = 0; i < _waveLength; i++)
            {
                //Spawns an enemy
                GameObject spawnEnemy = Instantiate(_enemy, transform.position, new Quaternion());
                //Prevents enemies from spawning until the timer is up
                yield return new WaitForSeconds(_spawnTimer);
            }
        }
    }
}
