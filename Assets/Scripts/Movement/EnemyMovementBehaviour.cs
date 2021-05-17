using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementBehaviour : MonoBehaviour
{
    [Tooltip("The rigidbody attached to this object")]
    [SerializeField]
    private Rigidbody _rigidbody;
    [Tooltip("The NavMeshAgent.")]
    private NavMeshAgent _navMeshAgent;
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

    private void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        //sets the destination to be the max X position
        Vector3 tempPos = new Vector3(_maxX.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z);
        _navMeshAgent.SetDestination(tempPos);
    }

    void Update()
    {
        //If the current x is greater than, or equal to, the max x set in unity, then the min X is the new destination and we go forward on the z by 2.
        if (_currentPosition.transform.position.x >= _maxX.transform.position.x)
        {
            Vector3 leftPos = new Vector3(_minX.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z - 2);
            _navMeshAgent.SetDestination(leftPos);
        }

        //If the current x is less than, or equal to, the min x set in unity, then the max X is the new destination and we go forward on the z by 2.
        if (_currentPosition.transform.position.x <= _minX.transform.position.x)
        {
            Vector3 rightPos = new Vector3(_maxX.transform.position.x, _currentPosition.transform.position.y, _currentPosition.transform.position.z - 2);
            _navMeshAgent.SetDestination(rightPos);
        }
    }
}
