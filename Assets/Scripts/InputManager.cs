using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputActions _inputActions;
    [SerializeField] Player _player;

    Vector2 _moveDirection;

    void Start()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Enable();
        _inputActions.Player.Jump.performed += Jump_performed;
    }

    void Update()
    {
        _moveDirection = _inputActions.Player.Run.ReadValue<Vector2>();

        if (_moveDirection == Vector2.zero)
            _player.Idle();

        else if (_moveDirection != Vector2.zero)
            _player.MovePlayer(_moveDirection);
    }

    void Jump_performed(InputAction.CallbackContext obj)
    {
        _player.Jump();
    }
}