using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [Tooltip("The enemy that will be spawned.")]
    [SerializeField]
    private GameObject _enemy;
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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    //Spawns enemies while _spawnEnemy is true
    public IEnumerator SpawnObjects()
    {
        while (_spawnEnemy)
        {
            //Spawns an enemy
            GameObject spawnEnemy = Instantiate(_enemy, transform.position, new Quaternion());
            //Prevents enemies from spawning until the timer is up
            yield return new WaitForSeconds(_spawnTimer);
        }
    }
}
