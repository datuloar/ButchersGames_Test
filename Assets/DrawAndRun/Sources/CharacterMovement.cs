using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stoppedDistance;

    private Vector3 _position;

    private void FixedUpdate()
    {
        if (_position == Vector3.zero)
            return;

        if (Vector3.Distance(transform.position, _position) > _stoppedDistance)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                _position, _speed * Time.deltaTime);
        }
    }

    public void Move(Vector3 position)
    {
        _position = position;
    }
}
