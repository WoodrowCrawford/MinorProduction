using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{

    private Rigidbody rigidbody;

    [Tooltip("The speed in which the player is moving around at")]
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // The Basic Clamp to prevent players moving  too far in one direction
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y, Mathf.Clamp(transform.position.z, -3, 3));

        // The inputs for left and right to move only when the button is press or held down
        if (Input.GetAxis("Horizontal") > 0)
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        // The inputs for left and right to move only when the button is press or held down
        if (Input.GetAxis("Horizontal") < 0)
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

        // The inputs for Front and Back to move only when the button is press or held down
        if (Input.GetAxis("Vertical") > 0)
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        // The inputs for Front and Back to move only when the button is press or held down
        if (Input.GetAxis("Vertical") < 0)
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;

    }
}
