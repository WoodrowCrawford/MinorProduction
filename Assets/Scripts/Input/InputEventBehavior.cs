using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEventBehavior : MonoBehaviour
{

    private PlayerMovementBehavior _movement;
    
    [SerializeField]
    private BulletSpawnBehaviour _gun;
    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<PlayerMovementBehavior>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement.Moving(context.ReadValue<Vector2>());
    }

    public void Fire(InputAction.CallbackContext context)
    {
        _gun.Shoot();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
