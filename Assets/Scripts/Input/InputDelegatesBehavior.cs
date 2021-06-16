using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegatesBehavior : MonoBehaviour
{
    // The controls made a variable for use
    private PlayerControls _controls;

    [Tooltip("The object and spawning behavior that is being used to fire")]
    [SerializeField]
    private BulletSpawnBehaviour _barrel1;

    [Tooltip("The second Barrel of the gun")]
    [SerializeField]
    private BulletSpawnBehaviour _barrel2;

    [Tooltip("The third Barrel of the gun")]
    [SerializeField]
    private BulletSpawnBehaviour _barrel3;

    [Tooltip("The time it takes for the player to shoot again")]
    [SerializeField]
    private float _playerShootcooldown;
    
    [SerializeField]
    private PowerUpScriptableObject RapidFire;

    [SerializeField]
    private PowerUpScriptableObject MultiShot;

    // A variable to hold the time the cooldown is set to
    private float _startingTimer;

    private float _backUpTimer;

    [SerializeField]
    private PauseBehavior Pause;

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
        //_controls.Player.Shoot.performed += context => _bulletSpawner.Shoot();
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
            if (Mouse.current.leftButton.isPressed || Keyboard.current.spaceKey.isPressed)
            {
                _barrel1.Shoot();
                _playerShootcooldown = _startingTimer;

                // Once the Spreadshot is collected the other two barrels are activated and can shoot!
                if (MultiShot.isActive)
                {
                    _barrel2.Shoot();
                    _barrel3.Shoot();

                    // When the timer of the power up is done the barrels are disabled and the timer is reset
                    if (MultiShot.PowerUpTimer <= 0)
                    {
                        MultiShot.isActive = false;
                        MultiShot.PowerUpTimer = MultiShot.BackupTimer;
                    }
                        
                    else
                        MultiShot.PowerUpTimer -= Time.deltaTime;
                }

                // This block of code is ran when a power up is active and collected
                if (RapidFire.isActive)
                {
                    _playerShootcooldown = 1;

                    // If the timer is equal to or less than 0 the rapid fire is turned off 
                    // the cooldown for the player shooting is reset 
                    // as well as the rapid fire time remaining.
                    if(RapidFire.PowerUpTimer <= 0)
                    {
                        RapidFire.isActive = false;
                        _playerShootcooldown = _startingTimer;
                        RapidFire.PowerUpTimer = RapidFire.BackupTimer;
                    }

                    RapidFire.PowerUpTimer -= Time.deltaTime;
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
