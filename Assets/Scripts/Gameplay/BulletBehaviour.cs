using System.Collections;
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

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void Awake()
    {
        //Get a reference to this object's rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Adds an initial force on start to get the bullet moving
        _rigidbody.AddForce(-transform.right * _velocity);
        //Destroys the bullet after a set despawn time
        Destroy(gameObject, _despawnTime);
    }

    private void Update()
    {
        //Adds a constant force to the rigidbody of the bullet every frame
        _rigidbody.AddForce(-transform.right * _velocity * Time.deltaTime);
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
