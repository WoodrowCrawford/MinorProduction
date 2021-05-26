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
        //Get a reference to the navMeshAgent in use
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //sets the targets destination on the NavMesh
        _navMeshAgent.SetDestination(_target.position);

        //adds the deltaTime to the StartCos to make the speed match gameplay
        StartCos += Time.deltaTime;

        //Makes the "boss" this script is put on move left and right
        transform.position += new Vector3(Mathf.Cos(StartCos), 0, 0) * HorizontalSpeed * Time.deltaTime;
    }
}
