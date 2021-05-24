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
        _rigidbody.AddForce(-transform.right * _velocity);
        Destroy(this.gameObject, _despawnTime);
    }

    private void Update()
    {
        _rigidbody.AddForce(-transform.right * _velocity * Time.deltaTime);
    }

    //COMPLETE WHEN HEALTHBEHAVIOUR IS DONE
    private void OnTriggerEnter(Collider other)
    {
        //I want to get a refference to the health behaviour then put that in a health behaviour
        HealthBehavior health = other.GetComponent<HealthBehavior>();

        //I then need to call takeDamage on the health if the bullet collides with something that 
        //has health
        if (health)
            health.TakeDamage(Damage);
    }
}
