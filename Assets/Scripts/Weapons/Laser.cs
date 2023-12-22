using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Gun
{
	public override void Shoot()
	{
		if (_currentBulletCount <= 0)
		{
			return;
		}

		Vector3 target = DefineTarget();
		Vector3 directionToTarget = target - transform.position;
		Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget, Vector3.up);

		GameObject bullet = Instantiate(BulletPrefab, AttackPoint.position, rotationToTarget, BulletContainer);
		LaserBullet basicBullet = bullet.GetComponent<LaserBullet>();
		basicBullet.SetOwner(this);
		_currentBulletCount--;

			
	}
}
