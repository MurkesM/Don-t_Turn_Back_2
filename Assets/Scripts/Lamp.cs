using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] Sprite _lampOnSprite;
    [SerializeField] GameObject _light;
    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _spriteRenderer.sprite = _lampOnSprite;
            _light.SetActive(true);
        }
    }
}