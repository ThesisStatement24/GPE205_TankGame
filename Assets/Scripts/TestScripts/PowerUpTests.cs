using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTests : MonoBehaviour
{
    public PowerUpManager powerupManager;

    // Start is called before the first frame update
    void Start()
    {
        powerupManager = GetComponent<PowerUpManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            HealthPowerUp newHealthPowerUp = new HealthPowerUp();

        }
        
    }
}
