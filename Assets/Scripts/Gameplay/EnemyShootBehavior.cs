using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBehavior : MonoBehaviour
{
    [SerializeField]
    private BulletSpawnBehaviour _EnemyGun;

    private float _startingTimer;

    [Tooltip("The time in between each shot the enemy makes")]
    [SerializeField]
    private float shootTimer;

    [Tooltip("The template of the bullet fired")]
    [SerializeField]
    private GameObject _EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        _startingTimer = shootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(shootTimer <= 0)
        {
            Instantiate(_EnemyBullet, _EnemyGun.transform.position, transform.rotation);
            shootTimer = _startingTimer;
        }
        else
        {
            shootTimer -= Time.deltaTime;
        }
    }
}
