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
    [Tooltip("The primary target the enemy will be seeking towards.")]
    [SerializeField]
    private Transform _target;
    [Tooltip("The target the enemy will hit before the primary target.")]
    [SerializeField]
    private Transform _tempTarget;
    [Tooltip("The NavMeshAgent.")]
    private NavMeshAgent _navMeshAgent;
    [Tooltip("The force that will be applied to object to move it.")]
    [SerializeField]
    private float _moveForce;
    [Tooltip("The maximum magnitude this enemy's velocity can have.")]
    [SerializeField]
    private float _maxVelocity;

    //The target is set here.
    public Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    public Transform TempTarget
    {
        get
        {
            return _tempTarget;
        }
        set
        {
            _tempTarget = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //If the temp target has been hit
        if (!TempTarget)
        {
            //Sets the targets position to be the enemies destination.
            _navMeshAgent.SetDestination(_target.position);
        }
        else
        {
            //Sets the targets position to be a temporary destination.
            _navMeshAgent.SetDestination(_tempTarget.position);
        }
    }
}
