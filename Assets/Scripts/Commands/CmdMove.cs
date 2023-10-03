using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMove : ICommand
{
    private CharacterController _controller;
    private Vector3 _moveVector;

    public CmdMove(CharacterController moveable, Vector3 moveVector) {
        _controller = moveable;
        _moveVector = moveVector;
    }

    public void Do() => _controller.Move(_moveVector);
}
