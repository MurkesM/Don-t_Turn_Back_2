using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 15;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        Vector3 _direction = new Vector3(x, 0, 0);

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(_direction, _moveSpeed, true);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(_direction, _moveSpeed, false);
        }
    }

    void MovePlayer(Vector2 direction, float moveSpeed, bool flipX)
    {
        _rigidbody.AddForce(direction * moveSpeed * Time.deltaTime);
        _animator.SetBool("isRunning", true);
        _spriteRenderer.flipX = flipX;
    }
}
