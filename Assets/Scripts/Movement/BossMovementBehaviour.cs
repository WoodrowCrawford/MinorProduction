using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BossMovementBehaviour : MonoBehaviour
{
    [Tooltip("The rigidbody attached to this object")]
    [SerializeField]
    private Rigidbody _rigidbody;
    [Tooltip("The object the enemy will be seeking towards.")]
    [SerializeField]
    private Transform _target;
    [Tooltip("The NavMeshAgent.")]
    private NavMeshAgent _navMeshAgent;
    public float HorizontalSpeed = 2;
    public float StartCos = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _navMeshAgent.SetDestination(_target.position);

        StartCos += Time.deltaTime;

        transform.position += new Vector3(Mathf.Cos(StartCos), 0, 0) * HorizontalSpeed * Time.deltaTime;
    }
}
