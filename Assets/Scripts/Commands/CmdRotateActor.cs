using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdRotateActor : ICommand
{
    private Transform _transform;
    private Vector3 _direction;
    private float _speed;


    public CmdRotateActor(Transform transform, Vector3 direction, float speed)
    {
        _transform = transform;
        _speed = speed;
        _direction = direction;
    }

    public void Do() => _transform.Rotate(_direction * Time.deltaTime * _speed, Space.Self);

}
