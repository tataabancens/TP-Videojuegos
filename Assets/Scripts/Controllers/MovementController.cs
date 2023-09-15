using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMoveable
{
    public float MovementSpeed => _movementSpeed;
    [SerializeField] private float _movementSpeed = 150f;

    public float TurnSpeed => _turnSpeed;
    [SerializeField] private float _turnSpeed = 700f;

    public void Move(Vector3 direction) => transform.Translate(direction * Time.deltaTime * MovementSpeed);

    public void Turn(Vector3 direction) => transform.Rotate(direction * Time.deltaTime * TurnSpeed, Space.Self);

}
