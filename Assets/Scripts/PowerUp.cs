using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerUp
{
    public float amount;
    public float lifespan;
    public AudioClip pickupsoundEffect;
    public AudioClip expiredsoundEffect;
    public GameObject particle;
    public TankData data;

    public virtual void OnPickUp() {



    }

    public virtual void OnExpire() {


    }

}
