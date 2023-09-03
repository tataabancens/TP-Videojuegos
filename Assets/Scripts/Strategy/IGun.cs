using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    GameObject BulletPrefab { get; }
    int Damage { get; }
    int AmmoCapacity { get; }
    Transform BulletContainer { get; }
    void Shoot();
    void Reload();

}
