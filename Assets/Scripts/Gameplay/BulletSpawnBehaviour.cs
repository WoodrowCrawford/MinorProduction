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
    [Tooltip("The one shooting the bullets.")]
    [SerializeField]
    private GameObject _owner;
    [Tooltip("The time before the bullet gets destroyed.")]
    [SerializeField]
    private float _despawnTime;

    private void Awake()
    {
        _bullet.GetComponent<BulletBehaviour>().Owner = _owner;
    }

    //Shoots a bullet when called
    public void Shoot()
    {
        //Spawns a bullet if the barrel is active
        if(_isActive == true)
        {
            Instantiate(_bullet, _barrel.position, _barrel.rotation);
            _bullet.GetComponent<BulletBehaviour>().Owner = _owner;
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
        }
    }
}
