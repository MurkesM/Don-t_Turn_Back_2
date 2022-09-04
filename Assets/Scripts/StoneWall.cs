using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _yDirection = -1;
    [SerializeField] float _duration = 1;

    public void Move()
    {
        Vector2 _newPosition = Vector2.Lerp(transform.position, new Vector2(transform.position.x, _yDirection), 1 * 
           _moveSpeed * Time.deltaTime);
       
        transform.position = _newPosition;
    }

    public IEnumerator MoveRoutine()
    {
        float time = 0;

        while (time < _duration)
        {
            Move();
            time += Time.deltaTime;
            yield return null;
        }
    }
}