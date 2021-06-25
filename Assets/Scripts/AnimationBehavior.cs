using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBehavior : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PlayerMovementBehavior _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", _playerMovement.Velocity.magnitude);
        
    }
}
