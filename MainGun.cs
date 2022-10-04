using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGun : Interactable
{
    public bool isShooting;
    public bool isReloaded;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isReloaded) Shoot();
        else if (!isReloaded) Reload();
    }

    public override string GetDescription()
    {
        if (isReloaded) return "Hold [E] to <color=red>reload</color> the gun.";
        return "Press [E] to <color=red>shoot</color> the main gun.";
    }

    public override void Interact()
    {
        isShooting = true;
    }

    void Shoot()
    {

    }

    void Reload()
    {

    }
}
