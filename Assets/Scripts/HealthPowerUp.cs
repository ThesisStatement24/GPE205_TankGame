using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{


    public override void OnPickUp()
    {
     //   data.health.damage(-amount);
        base.OnPickUp();
    }

    public override void OnExpire()
    {
       // data.health.damage(amount);
        base.OnExpire();
    }
}
