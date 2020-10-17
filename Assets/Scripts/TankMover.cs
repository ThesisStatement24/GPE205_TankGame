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

    void FixedUpdate()
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

    public void MoveTo(Transform targetTransform)
    {
        RotateTowards(targetTransform);

        cc.SimpleMove(transform.forward * Data.speed);
    }

    public void RotateTowards(Transform targetTransform)
    {

        Vector3 targetPosition = targetTransform.position;
        targetPosition.y = transform.position.y;

        Vector3 targetVector = targetTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetVector);
        Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Data.rotateSpeed *Time.deltaTime);
        transform.rotation = newRotation;
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
