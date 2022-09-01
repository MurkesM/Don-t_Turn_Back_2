using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 15;
    [SerializeField] float _jumpForce = 30;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] CapsuleCollider2D _collider;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Transform feet;

    bool isGrounded = true;

    void Start()
    {
        
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
        if (isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    public void Slide(bool isSliding)
    {
        _animator.SetBool("isSliding", isSliding);

        if (isSliding == true)
            _collider.size = new Vector2(0.16f, 0.16f);
        else
            _collider.size = new Vector2(0.16f, 0.31f);

        //need to fix direction of sprite, probabaly best to fix it in the animation if possible to save on code
    }

    public void Idle()
    {
        _animator.SetBool("isRunning", false);
    }

    void GroundCheck()
    {
        var hit = Physics2D.OverlapCircle(feet.position, 0.1f, LayerMask.GetMask("Ground"));

        if (hit != null)
        {
            _animator.SetBool("isJumping", false);
            isGrounded = true;
        }
        else if (hit == null)
        {
            _animator.SetBool("isJumping", true);
            isGrounded = false;
        }
    }  
}