using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReload : ICommand
{
    private IGun _gun;
    

    public CmdReload(IGun gun)
    {
        _gun = gun;
    }

    public void Do() => _gun.Reload();

}
