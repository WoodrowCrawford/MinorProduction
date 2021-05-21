using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegatesBehavior : MonoBehaviour
{
    // The controls made a variable for use
    private PlayerControls _controls;

    [Tooltip("The objecy and spawning behavior that is being used to fire")]
    [SerializeField]
    private BulletSpawnBehaviour _bulletSpawner;

    [Tooltip("The time it takes for the player to shoot again")]
    [SerializeField]
    private float _playerShootcooldown;

    // A variable to hold the time the cooldown is set to
    private float _startingTimer;

    // A bool to check if the power up is being used
    [SerializeField]
    private bool _powerUpActive;

    private float _backUpTimer;

    private PlayerMovementBehavior _movement;

    public void Awake()
    {
        _controls = new PlayerControls();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingTimer = _playerShootcooldown;
        _backUpTimer = _startingTimer;
        _movement = GetComponent<PlayerMovementBehavior>();
        _controls.Player.Shoot.started += context => _bulletSpawner.Shoot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // A vector to chenage the the y of the read value to be the z instead for the player to move forward
        Vector3 MoveDirection = new Vector3(_controls.Player.Movement.ReadValue<Vector2>().x, 0, _controls.Player.Movement.ReadValue<Vector2>().y);
        _movement.Move(MoveDirection);

        
        // If the cooldown is 0 then the player is allowed to shoot
       if(_playerShootcooldown <= 0)
       {
            _controls.Player.Shoot.Enable();

            // Waits for the player to shoot before restarting the timer
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _playerShootcooldown = _startingTimer;

                if (_powerUpActive)
                {
                    _playerShootcooldown = 3;
                }
            }
       }

       // If the timer is not 0 or lower, the player shooting is disabled and 
       // the cooldown is subtracted from the time passed between frames
       else
       {
            _controls.Player.Shoot.Disable();
           _playerShootcooldown -= Time.deltaTime;
       }

    }
}
