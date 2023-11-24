using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/WeaponStats", order = 0)]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private WeaponStatsValues _weaponStats;

    public int MagazineSize => _weaponStats.MagazineSize;
    public int Damage => _weaponStats.Damage;
    public GameObject BulletPrefab => _weaponStats._bulletPrefab;
    public AudioClip ShootAudioClip => _weaponStats.shootAudioClip;
    public AudioClip ReloadAudioClip => _weaponStats.reloadAudioClip;
}

[System.Serializable]
public struct WeaponStatsValues {
    public int MagazineSize;
    public int Damage;
    public GameObject _bulletPrefab;
    public AudioClip shootAudioClip;
    public AudioClip reloadAudioClip;
}
