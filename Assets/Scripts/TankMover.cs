﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{

    private CharacterController cc;
    private TankData Data;

    // Start is called before the first frame update
    void Start()
    {

        cc = GetComponent<CharacterController>();

        cc.slopeLimit = 90;
        cc.stepOffset = 0.0f;

        Data = GetComponent<TankData>();
        
    }


    public void Move (bool isForward)
    {

        if (isForward)
        {

            cc.SimpleMove(transform.forward * Data.speed);

        } else {

            cc.SimpleMove(-transform.forward * Data.speed);

        }

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
}
