using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiffleBullet : BasicBullet
{
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        _rigidbody.AddForce(Vector3.forward * Speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Choque");
    }
}
