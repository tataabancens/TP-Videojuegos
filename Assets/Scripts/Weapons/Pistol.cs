using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
	public override void Shoot()
	{
		if (_currentBulletCount <= 0)
		{
			return;
		}

		GameObject bullet = Instantiate(BulletPrefab, AttackPoint.position, AttackPoint.rotation, BulletContainer);
		BasicBullet basicBullet = bullet.GetComponent<BasicBullet>();
		basicBullet.SetOwner(this);
		_currentBulletCount--;

		RaycastHit hit;
		if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity)) {
			Debug.Log(hit.point);
			basicBullet.AddForceTowards(hit.point);
		} else {
			Debug.Log("There");
			basicBullet.AddForceTowards(_cameraTransform.position + _cameraTransform.forward * _bulletHitMissDistance);
		}	
	}
}
