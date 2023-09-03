using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
	[SerializeField] private int _bulletPerShot = 7;

	public override void Shoot() {
		if (_currentBulletCount <= 0) {
			return;
		}

		for (int i = 0; i < _bulletPerShot; i++) {
			GameObject bullet = Instantiate(BulletPrefab,
				transform.position + Random.insideUnitSphere * 1, 
				transform.rotation, 
				BulletContainer);
			
			bullet.GetComponent<BasicBullet>().SetOwner(this);
		}
		_currentBulletCount--;
	}
}
