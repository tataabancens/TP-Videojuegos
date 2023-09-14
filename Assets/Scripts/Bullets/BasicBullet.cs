using System;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class BasicBullet : MonoBehaviour, IBullet
{
	#region PRIVATE_PROPERTIES
	[SerializeField] private float _lifetime = 3f;
	[SerializeField] private float _speed = 3f;
	[SerializeField] private LayerMask _hittableMask;
	protected Collider _collider;
	protected Rigidbody _rigidbody;
	private IGun _owner;
	#endregion

	#region UNITY_METHODS
	protected void Start()
	{
		_collider = GetComponent<Collider>();
		_rigidbody = GetComponent<Rigidbody>();
		Init();
	}
	void Update()
	{
		// Travel();

		_lifetime -= Time.deltaTime;
		if (_lifetime < 0) Die();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (((1 << other.gameObject.layer) & _hittableMask) != 0)
		{
			other.GetComponent<Actor>()?.TakeDamage(_owner.Stats.Damage);
			Die();
		}
	}

	#endregion

	#region IBULLET_PROPERTIES
	public float Lifetime => _lifetime;
	public IGun Owner => _owner;
	public float Speed => _speed;

	public Collider Collider => _collider;
	public Rigidbody RB => _rigidbody;
	#endregion

	#region IBULLET_METHODS
	public void Die() => Destroy(gameObject);
	public void SetOwner(IGun owner) => _owner = owner;

	public void Init()
	{
		// _collider.isTrigger = true;
		_rigidbody.useGravity = false;
		_rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		_rigidbody.AddForce(transform.forward * Speed, ForceMode.Impulse);
	}

	public void Travel() => transform.Translate(Vector3.forward * Time.deltaTime * _speed);
	#endregion
}
