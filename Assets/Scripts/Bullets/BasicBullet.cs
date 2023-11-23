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

	[SerializeField] GameObject _bulletDecal;
	[SerializeField] private TrailRenderer _trailRenderer;

	#endregion

	#region UNITY_METHODS
	protected void Awake() {
		_collider = GetComponent<Collider>();
		_rigidbody = GetComponent<Rigidbody>();
		_trailRenderer = GetComponent<TrailRenderer>();
		Init();
	}

	private void OnEnable() {
		Destroy(gameObject, Lifetime);
	}

	private void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.GetContact(0);

		IFreezable freezable = collision.gameObject.GetComponent<IFreezable>();
		if (freezable != null) {
			freezable.UnFreeze();
			return;
		}
		//GameObject decalObject = GameObject.Instantiate(_bulletDecal, contact.point + contact.normal * 0.001f,
		//Quaternion.LookRotation(contact.normal));

		Destroy(gameObject);
	}

	private void OnCollisionExit(Collision collision) {
		//Destroy(gameObject);
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
		_rigidbody.useGravity = false;
		_rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}

	public void InitialSpeed(Vector3 target) {
		if (target == null) return;
		Vector3 direction = (target - transform.position).normalized;
		if (_rigidbody == null) Debug.Log("Null rigid");
		_rigidbody.AddForce(direction * Speed, ForceMode.Impulse);
	}

	public void Travel() => transform.Translate(Vector3.forward * Time.deltaTime * _speed);
	#endregion
}
