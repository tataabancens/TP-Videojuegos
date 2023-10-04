using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IFreezable
{
    private Rigidbody _rigidbody;
    private Vector3 _initialPosition;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

	#region IFREEZABLE
    public void Freeze() {
        _rigidbody.angularVelocity = new Vector3(0, 0, 0);
        _rigidbody.velocity = new Vector3(0, 0, 0);

        _rigidbody.useGravity = false;
    }

    public void UnFreeze() {
        _rigidbody.useGravity = true;
    }
	#endregion

	public void RespawnBall() {
        Freeze();
        UnFreeze();
        transform.position = _initialPosition;
	}
}
