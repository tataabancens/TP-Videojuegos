using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _initialPosition;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnBall() {
        _rigidbody.angularVelocity = new Vector3(0, 0, 0);
        _rigidbody.velocity = new Vector3(0, 0, 0);

        transform.position = _initialPosition;
	}
}
