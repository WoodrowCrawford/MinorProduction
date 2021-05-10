using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegatesBehavior : MonoBehaviour
{
    private PlayerControls _controls;

    [SerializeField]
    private BulletSpawnBehaviour _bulletSpawner;

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
        _movement = GetComponent<PlayerMovementBehavior>();
        _controls.Player.Shoot.performed += context => _bulletSpawner.Shoot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _movement.Moving(_controls.Player.Movement.ReadValue<Vector2>());
    }
}
