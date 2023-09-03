using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
	public override void Shoot() {
		if (_currentBulletCount <= 0) {
			return;
		}
		Instantiate(BulletPrefab, transform.position, transform.rotation, BulletContainer);
	}
}
