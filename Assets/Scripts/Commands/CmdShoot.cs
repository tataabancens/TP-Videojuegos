using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdShoot : ICommand
{
    private IGun _gun;


    public CmdShoot(IGun gun)
    {
        _gun = gun;
    }

    public void Do() => _gun.Shoot();

}
