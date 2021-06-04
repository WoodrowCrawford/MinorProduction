using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBurstBehavior : MonoBehaviour
{
    [SerializeField]
    private BulletSpawnBehaviour _BulletSpawner;

    [SerializeField]
    private float StartingTime;

    private float ShootTimer;

    [SerializeField]
    private GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartingTime = ShootTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShootTimer == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(Bullet, _BulletSpawner.transform.position, transform.rotation);
            }

            ShootTimer = StartingTime;
        }
        else
        {
            ShootTimer -= Time.deltaTime;
        }
    }
}
