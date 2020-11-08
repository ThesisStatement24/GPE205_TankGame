using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;
    public float health;
    public float damageDone;
    public float shootDelay; //Shots per second
    public float fireRate;

    

    public GameObject Bullet;
    public Transform Gun1;

    public TankMover mover;

    // Start is called before the first frame update
    void Start()
    {
        
        mover = GetComponent<TankMover>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
