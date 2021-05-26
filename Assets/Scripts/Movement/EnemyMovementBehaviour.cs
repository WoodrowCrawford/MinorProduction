using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementBehaviour : MonoBehaviour
{
    [Tooltip("The rigidbody attached to this object")]
    [SerializeField]
    private Rigidbody _rigidbody;
    [Tooltip("The force that will be applied to object to move it.")]
    [SerializeField]
    private float _moveForce;
    [Tooltip("The maximum magnitude this enemy's velocity can have.")]
    [SerializeField]
    private float _maxVelocity;
    [Tooltip("The transform position of the enemy.")]
    [SerializeField]
    private Transform _currentPosition;
    [Tooltip("The minimum X position for the enemy.")]
    [SerializeField]
    private Transform _minX;
    [Tooltip("The maximum X position for the enemy.")]
    [SerializeField]
    private Transform _maxX;
    [Tooltip("The max z that the enemy can go.")]
    [SerializeField]
    private Transform _zMin;


    public Transform minX
    {
        get
        {
            return _minX;
        }
        set
        {
            _minX = value;
        }
    }

    public Transform maxX
    {
        get
        {
            return _maxX;
        }
        set
        {
            _maxX = value;
        }
    }

    public Transform zMin
    {
        get
        {
            return _zMin;
        }
        set
        {
            _zMin = value;
        }
    }

    private void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();

        //sets the destination to be the max X position
        Vector3 tempPos = new Vector3(_maxX.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z);
        transform.position = Vector3.MoveTowards(_currentPosition.position, tempPos, _moveForce);
    }

    //USE A FIXED UPDATE WHEN UTILIZING RIGIDBODY AND REMOVE THE NAVMESH MOVEMENT (IT IS UNNECCESSARY)
    //MAKING ENEMIES A TRIGGER CAN HELP!!

    void FixedUpdate()
    {
        float moveForce = _moveForce * Time.deltaTime;

        //If the current x is greater than, or equal to, the max x set in unity, then the min X is the new destination and we go forward on the z by 2.
        if (_currentPosition.transform.position.x >= _maxX.transform.position.x)
        {
            Vector3 leftPos = new Vector3(_minX.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z);
            Vector3 lowerPos = new Vector3(_currentPosition.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z - 2);
            transform.position = Vector3.MoveTowards(_currentPosition.position, lowerPos, moveForce);
            transform.position = Vector3.MoveTowards(_currentPosition.position, leftPos, moveForce);
        }

        //If the current x is less than, or equal to, the min x set in unity, then the max X is the new destination and we go forward on the z by 2.
        if (_currentPosition.transform.position.x <= _minX.transform.position.x)
        {
            Vector3 rightPos = new Vector3(_maxX.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z);
            Vector3 lowerPos = new Vector3(_currentPosition.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z - 2);
            transform.position = Vector3.MoveTowards(_currentPosition.position, lowerPos, moveForce);
            transform.position = Vector3.MoveTowards(_currentPosition.position, rightPos, moveForce);
        }
    }
}
