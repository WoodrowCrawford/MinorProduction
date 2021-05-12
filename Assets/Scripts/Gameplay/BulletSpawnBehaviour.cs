using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnBehaviour : MonoBehaviour
{
    [Tooltip("The barrel the 'bullets' will come from.")]
    [SerializeField]
    private Transform _barrel;
    [Tooltip("A bool that tells the 'gun barrel' if it will shoot or not.")]
    [SerializeField]
    private bool _isActive;
    [Tooltip("The bullet that will be shot.")]
    [SerializeField]
    private GameObject _bullet;
    [Tooltip("The time it takes before the bullet despawns.")]
    [SerializeField]
    private float _despawnTime;

    //Shoots a bullet when called
    public void Shoot()
    {
        //Spawns a bullet if the barrel is active
        if(_isActive == true)
        {
            Instantiate(_bullet, _barrel.position, _barrel.rotation);
        }
    }
}
