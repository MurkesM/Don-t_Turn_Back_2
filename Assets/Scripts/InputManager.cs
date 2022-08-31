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
        //input for running is not working. The only thing thats giving issue is actually applying force from the vector 2
        //probabaly need to look at bindings
        _inputActions = new InputActions();
        _inputActions.Player.Enable();

        _inputActions.Player.Jump.performed += Jump_performed;
    }

    void Update()
    {
        _moveDirection = _inputActions.Player.Run.ReadValue<Vector2>();
        _player.MovePlayer(_moveDirection);

        if (_moveDirection == Vector2.zero)
            _player.Idle();
    }

    void Jump_performed(InputAction.CallbackContext obj)
    {
        _player.Jump();
    }
}
