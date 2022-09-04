using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 15;
    [SerializeField] float _jumpForce = 30;
    [SerializeField] Transform feet;

     Rigidbody2D _rigidbody;
     CapsuleCollider2D _collider;
     Animator _animator;
     SpriteRenderer _spriteRenderer;
    

    bool _isGrounded = true;
    LayerMask _groundLayer;

    void Start()
    {
        _groundLayer = LayerMask.GetMask("Ground");

        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GroundCheck();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GroundCheck();
    }

    public void MovePlayer(Vector2 direction)
    {
        _rigidbody.AddForce(_moveSpeed * Time.fixedDeltaTime * direction, ForceMode2D.Force);
        _animator.SetBool("isRunning", true);

        if (direction.x > 0)
            _spriteRenderer.flipX = false;
        else if (direction.x < 0)
            _spriteRenderer.flipX = true;
    }

    public void Jump()
    {
        if (_isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    public void Slide(bool isSliding)
    {
        if (isSliding == true)
        {
            _animator.SetBool("isSliding", isSliding);
            _collider.size = new Vector2(0.16f, 0.16f);
        }
        else
        {
            _animator.SetBool("isSliding", isSliding);
            _collider.size = new Vector2(0.16f, 0.31f);
        }
    }

    public void Idle()
    {
        _animator.SetBool("isRunning", false);
    }

    void GroundCheck()
    {
        var hit = Physics2D.OverlapCircle(feet.position, 0.1f, _groundLayer);

        if (hit != null)
        {
            _animator.SetBool("isJumping", false);
            _isGrounded = true;
        }
        else if (hit == null)
        {
            _animator.SetBool("isJumping", true);
            _isGrounded = false;
        }
    }  
}