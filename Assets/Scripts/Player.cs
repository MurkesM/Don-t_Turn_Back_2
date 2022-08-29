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

    void Update()
    {
        //Seperate out movement into another script and have the script communicate to the player with delegates if possible.
        //Either way seperate out the input handeling into Update() and the RB stuff into Fixed Update()
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        _direction = new Vector2(x, 0);

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer();
            _spriteRenderer.flipX = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            MovePlayer();
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void MovePlayer()
    {
        _rigidbody.AddForce(_direction * _moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        _animator.SetBool("isRunning", true);
    }

    void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        Debug.Log("Jump");
    }
}
