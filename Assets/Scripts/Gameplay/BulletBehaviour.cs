﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody; 
    [Tooltip("How fast the bullet is.")]
    [SerializeField]
    private float _velocity = 10;
    [Tooltip("The damage the bullet deals once hit.")]
    [SerializeField]
    private float _damage = 1;
    [Tooltip("The time before despawning the bullet.")]
    [SerializeField]
    private float _despawnTime;

    //grabs the reference of the rigidbody and sets it in code
    public Rigidbody Rigidbody
    {
        get
        {
            return _rigidbody;
        }
    }

    private void Awake()
    {
        //Get a reference to this object's rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.AddForce(transform.forward * _velocity);
        Destroy(gameObject, _despawnTime);
    }

    private void Update()
    {
        _rigidbody.AddForce(transform.forward * _velocity * Time.deltaTime);
    }

    //COMPLETE WHEN HEALTHBEHAVIOUR IS DONE
    private void OnTriggerEnter(Collider other)
    {
        //Create a HealthBehaviour variable and set it equal to the health of what the bullet collides with
        /*HealthBehaviour health = other.GetComponent<HealthBehaviour>();

        //If the bullet collides with something that has health, call TakeDamage
        if (health)
            health.TakeDamage(Damage);*/
    }
}
