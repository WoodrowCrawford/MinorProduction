using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegatesBehavior : MonoBehaviour
{
    private PlayerControls _controls;

    [SerializeField]
    private BulletSpawnBehaviour _bulletSpawner;

    [SerializeField]
    private float _playerShootcooldown;

    private float _startingTimer;

    private PlayerMovementBehavior _movement;

    private bool CanShoot = false;

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
        _movement = GetComponent<PlayerMovementBehavior>();
        _controls.Player.Shoot.started += context => _bulletSpawner.Shoot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 MoveDirection = new Vector3(_controls.Player.Movement.ReadValue<Vector2>().x, 0, _controls.Player.Movement.ReadValue<Vector2>().y);
        _movement.Move(MoveDirection);

       if(_playerShootcooldown <= 0)
       {
            _controls.Player.Shoot.Enable();

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _playerShootcooldown = _startingTimer;
            }
            

       }
       else
       {
            _controls.Player.Shoot.Disable();
           _playerShootcooldown -= Time.deltaTime;
       }

    }
}
