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
	private Collider _collider;
	private Rigidbody _rigidbody;
	private IGun _owner;
	#endregion

	#region UNITY_METHODS
	void Start()
	{
		_collider = GetComponent<Collider>();
		_rigidbody = GetComponent<Rigidbody>();
		Init();
	}
	void Update()
	{
		Travel();

		_lifetime -= Time.deltaTime;
		if (_lifetime < 0) Die();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (((1 << other.gameObject.layer) & _hittableMask) != 0)
		{
			//other.GetComponent<Actor>()?.TakeDamage(_owner.Damage);
			if(other.GetComponent<IDamageable>() != null)
            {
				new CmdApplyDamage(other.GetComponent<IDamageable>(), _owner.Damage).Do();

			}
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
		_collider.isTrigger = true;
		_rigidbody.isKinematic = true;
		_rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}

	public void Travel() => transform.position += Vector3.forward * Time.deltaTime * _speed;
	#endregion
}
