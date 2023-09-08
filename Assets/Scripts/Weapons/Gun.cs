using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
	#region IGUN_PROPERTIES
	public GameObject BulletPrefab => _bulletPrefab;
	public Transform BulletContainer => _bulletContainer;
	public Transform AttackPoint => _attackPoint;
	public int Damage => _damage;
	public int AmmoCapacity => _ammoCapacity;
	#endregion

	#region PRIVATE_PROPERTIES
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private Transform _bulletContainer;
	[SerializeField] private Transform _attackPoint;
	[SerializeField] private int _damage = 10;
	[SerializeField] private int _ammoCapacity = 15;
	protected int _currentBulletCount;
	#endregion

	#region UNITY_EVENTS
	void Start() {
		Reload();
	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region IGUN_METHODS
	public void Reload() => _currentBulletCount = _ammoCapacity;

	public virtual void Shoot() => Debug.Log("Implementa el disparo gato");
	#endregion

	// Start is called before the first frame update

}
