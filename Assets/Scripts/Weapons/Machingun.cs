using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machingun : Gun
{
    [SerializeField] private int _bulletPerShot = 5;

	public override void Shoot() {
		if (_currentBulletCount <= 0) {
			return;
		}

		for (int i = 0; i < _bulletPerShot; i++) {
			Instantiate(BulletPrefab, transform.position + Vector3.forward * i * .6f, transform.rotation, BulletContainer);
			_currentBulletCount--;
		}
	}
}
