using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    

    private Rigidbody rigidbody;

    private Vector3 _velocity;

    [Tooltip("The speed in which the player is moving around at")]
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // A function to move using delegate events 
    public void Move(Vector3 Direction)
    {
        _velocity = speed * Direction * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // The Basic Clamp to prevent players moving  too far in one direction
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), transform.position.y, Mathf.Clamp(transform.position.z, -3, 3));
     

        rigidbody.MovePosition(transform.position + _velocity);
        
    }
}
