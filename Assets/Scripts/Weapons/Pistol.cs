using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
	[SerializeField] private ParticleSystem _particleSystem;
	public override void Shoot()
	{
		if (_currentBulletCount <= 0)
		{
			return;
		}
		_particleSystem.Play();
		GameObject bullet = Instantiate(BulletPrefab, AttackPoint.position, AttackPoint.rotation, BulletContainer);
		BasicBullet basicBullet = bullet.GetComponent<BasicBullet>();
		basicBullet.SetOwner(this);
		_currentBulletCount--;

		RaycastHit hit;
		if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, Mathf.Infinity)) {
			basicBullet.InitialSpeed(hit.point);
		} else {
			Debug.Log("There");
			basicBullet.InitialSpeed(_cameraTransform.position + _cameraTransform.forward * _bulletHitMissDistance);
		}	
	}
}
