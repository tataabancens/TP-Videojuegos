using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
	public override void Shoot() {
		if (_currentBulletCount <= 0) {
			return;
		}
		GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation, BulletContainer);
		bullet.GetComponent<BasicBullet>().SetOwner(this);
		_currentBulletCount--;
	}
}
