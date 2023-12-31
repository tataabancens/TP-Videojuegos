using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    GameObject BulletPrefab { get; }
    // int Damage { get; }
    // int AmmoCapacity { get; }
    WeaponStats Stats { get; }
    Transform BulletContainer { get; }
    Transform AttackPoint { get;  }
    void Shoot();
    void Reload();

}
