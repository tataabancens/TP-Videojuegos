using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour, IBullet
{
	#region PRIVATE_PROPS
	private Collider _collider;
	private Rigidbody _rigidbody;
	[SerializeField] private float _lifetime = 3f;
	[SerializeField] private float _speed = 3f;
	[SerializeField] private LayerMask _hittableMask;
	private IGun _owner;
	#endregion


	void Awake() {
		_collider = GetComponent<Collider>();
		_rigidbody = GetComponent<Rigidbody>();
		Init();
	}

	void Start()
    {
        
    }

	private void FixedUpdate() {
		Travel();
	}

	private void OnTriggerEnter(Collider other) {
		if (((1 << other.gameObject.layer) & _hittableMask) != 0) {
			
			if (other.CompareTag("Pelota")) {
				Ball ball = other.gameObject.GetComponent<Ball>();
				ball.Freeze();
			}
			Debug.Log("Hit a : " + other.gameObject.name);
			Die();
		}
	}

	#region IBULLET_PROPS
	public float Lifetime => _lifetime;
	public IGun Owner => _owner;
	public float Speed => _speed;
	public Collider Collider => _collider;
	public Rigidbody RB => _rigidbody;
	#endregion

	public void Init() {
		_collider.isTrigger = true;
		_rigidbody.isKinematic = true;
		_rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}

	public void Travel() => transform.Translate(Vector3.forward * Time.deltaTime * _speed);

	public void Die() {
		Destroy(gameObject);
	}

	public void SetOwner(IGun owner) {
		_owner = owner;
	}

	public void InitialSpeed(Vector3 target) {
		throw new NotImplementedException();
	}
}
