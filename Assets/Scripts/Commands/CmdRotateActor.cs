using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdRotateActor : ICommand
{
    private IMoveable _moveable;
    private Vector3 _direction;


    public CmdRotateActor(IMoveable moveable, Vector3 direction)
    {
        _moveable = moveable;
        _direction = direction;
    }

    public void Do() => _moveable.Turn(_direction);

}
