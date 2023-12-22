using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
	#region IGUN_PROPERTIES
	public GameObject BulletPrefab => _stats.BulletPrefab;
	public Transform BulletContainer => _bulletContainer;
	public Transform AttackPoint => _attackPoint;
	[SerializeField] public float _bulletHitMissDistance = 25f;

	public WeaponStats Stats => _stats;
	[SerializeField] private WeaponStats _stats;
	public int Damage => _stats.Damage;
	#endregion

	#region PRIVATE_PROPERTIES
	[SerializeField] private Transform _bulletContainer;
	[SerializeField] private Transform _attackPoint;
	public int _currentBulletCount;
	protected Transform _cameraTransform;
	#endregion

	#region UNITY_EVENTS
	void Start() {
		Reload();
		_cameraTransform = Camera.main.transform;
	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region IGUN_METHODS
	public void Reload() => _currentBulletCount = Stats.MagazineSize;

	public virtual void Shoot() => Debug.Log("Implementa el disparo gato");

	public Vector3 DefineTarget() {
		RaycastHit hit;
		if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity)) {
			return hit.point;
		} else {
			return _cameraTransform.position + _cameraTransform.forward * _bulletHitMissDistance;
		}
	}
	#endregion

}
