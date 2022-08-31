using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 15;
    [SerializeField] float _jumpForce = 30;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    Vector2 _direction;

    void Start()
    {
        
    }

    public void MovePlayer(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        _animator.SetBool("isRunning", true);

        if (direction.x > 0)
            _spriteRenderer.flipX = false;
        else if (direction.x < 0)
            _spriteRenderer.flipX = true;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        Debug.Log("Jump");
    }

    public void Idle()
    {
        _animator.SetBool("isRunning", false);
    }
}