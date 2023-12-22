using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPistol: Gun
{
	[SerializeField] private ParticleSystem _particleSystem;
	public override void Shoot(Vector3 target)
	{
		_particleSystem.Play();
		GameObject bullet = Instantiate(BulletPrefab, AttackPoint.position, AttackPoint.rotation, BulletContainer);
		BasicBullet basicBullet = bullet.GetComponent<BasicBullet>();
		basicBullet.SetOwner(this);
		_currentBulletCount--;

		basicBullet.InitialSpeed(target);
	}
}
