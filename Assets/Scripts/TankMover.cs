using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{

    private CharacterController cc;
    private TankData Data;
    private Bullet RBbullet;

    // Start is called before the first frame update
    void Start()
    {

        cc = GetComponent<CharacterController>();

        cc.slopeLimit = 90;
        cc.stepOffset = 0.0f;

        Data = GetComponent<TankData>();
        
    }

    void Update()
    {

        Data.shootDelay -= Time.deltaTime;
        

    }


        public void Move (Vector3 direction)
    {

            cc.SimpleMove(direction * Data.speed);

    }

    public void Rotate (bool isClockwise)
    {

        if (isClockwise)
        {

            transform.Rotate(new Vector3(0, Data.rotateSpeed * Time.deltaTime, 0));

        }
        else
        {

            transform.Rotate(new Vector3(0, -Data.rotateSpeed * Time.deltaTime, 0));

        }


    }

    public void Shoot()
    {
        
        if(Data.shootDelay <= 0)
        {

            Data.shootDelay = Data.fireRate;
            Instantiate(Data.Bullet , Data.Gun1.position, Data.Gun1.rotation); // Create a new bullet
            
        }
        

    }
}
