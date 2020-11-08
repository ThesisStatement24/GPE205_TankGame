using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public List<PowerUp> powerups;

    public TankData data;
    /*
    void Start()
    {
        powerups = new List<PowerUp>();
        if (data == null) data = gameObject.GetComponent<TankData>();
    }
    void Update()
    {
        List<PowerUp> expiredPowerups = new List<PowerUp>();
        foreach (PowerUp power in powerups)
        {
            power.duration -= Time.deltaTime;

            if (power.duration <= 0)
            {
                expiredPowerups.Add(power);
            }
        }
        foreach (PowerUp power in expiredPowerups)
        {
            power.OnDeactivate(data);
            powerups.Remove(power);
        }
        expiredPowerups.Clear();
    }

    public void Add(PowerUp powerup)
    {
        powerup.OnActivate(data);
        if (!powerup.isPermanent) powerups.Add(powerup);
    }
    */
}
