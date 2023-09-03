using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{

    float Lifetime { get; }
    IGun Owner { get;  }
    float Speed { get; }

    Collider Collider { get; }
    Rigidbody RB { get; }

    void Init();
    void Travel();
    void Die();
    void SetOwner(IGun owner);
}