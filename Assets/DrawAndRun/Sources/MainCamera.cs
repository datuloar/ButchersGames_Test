using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
    private ICameraTarget _currentTarget;
    private Vector3 _offset;

    private void LateUpdate()
    {
        if (_currentTarget == null) 
            return;

        FollowTarget();
    }

    public void SetTarget(ICameraTarget target)
    {
        _currentTarget = target;
        _offset = transform.position - target.transform.position;
    }

    private void FollowTarget()
    {
        transform.position = _currentTarget.transform.position + _offset;
    }
}
