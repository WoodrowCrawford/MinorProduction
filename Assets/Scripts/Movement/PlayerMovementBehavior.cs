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

    public void Moving(Vector3 Direction)
    {
        _velocity = speed * Direction * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // The Basic Clamp to prevent players moving  too far in one direction
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y, Mathf.Clamp(transform.position.z, -3, 3));

        rigidbody.MovePosition(transform.position + _velocity);

    }
}
