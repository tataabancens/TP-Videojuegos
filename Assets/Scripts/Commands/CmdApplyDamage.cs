using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdApplyDamage : ICommand
{
    private IDamageable _damageable;
    private int _damage;


    public CmdApplyDamage(IDamageable damageable, int damage)
    {
        _damageable = damageable;
        _damage = damage;
    }

    public void Do() => _damageable.TakeDamage(_damage);

}
