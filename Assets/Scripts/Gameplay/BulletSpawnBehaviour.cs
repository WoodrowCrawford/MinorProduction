using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnBehaviour : MonoBehaviour
{
    [Tooltip("The bullet that will be shot.")]
    [SerializeField]
    private GameObject _bullet;
    [Tooltip("The time it takes before the bullet despawns.")]
    [SerializeField]
    private float _despawnTime;

    //Shoots a bullet when called
    public void Shoot()
    {
        //Spawn a bullet
        Instantiate(_bullet, transform.position, transform.rotation);
    }

    private void Update()
    {
        Destroy(_bullet, _despawnTime);
    }
}
