using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] StoneWall _stoneWall;
    Animator _animator;
    Collider2D _collider;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _animator.SetBool("rotateLever", true);
            StartCoroutine(_stoneWall.MoveRoutine());
            _collider.enabled = false;
        }
    }
}
