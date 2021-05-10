using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Tooltip("A reference to the bullet.")]
    [SerializeField]
    private Rigidbody _bullet;
    [Tooltip("How fast the bullet is.")]
    [SerializeField]
    private float _velocity;
    [Tooltip("The damage the bullet deals once hit.")]
    [SerializeField]
    private float _damage;

    // Start is called before the first frame update
    void Start()
    {
        _bullet.AddForce(transform.forward * _velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //COMPLETE WHEN HEALTHBEHAVIOUR IS DONE
    private void OnTriggerEnter(Collider other)
    {
        //I want to get a refference to the health behaviour then put that in a health behaviour

        //I then need to call takeDamage on the health if the bullet collides with something that 
        //has health
    }
}
