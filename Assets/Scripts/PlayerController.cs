using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TankMover mover;
    public enum ControlType { WASD, ArrowKeys };
    public ControlType controlType;

    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {

        if(controlType == ControlType.WASD)
        {

            if (Input.GetKey(KeyCode.W))
            {
                //Move Forward (+)
                mover.Move(true);

            }

            if (Input.GetKey(KeyCode.A))
            {
                //Rotate CounterClockwise (-)
                mover.Rotate(false);

            }

            if (Input.GetKey(KeyCode.S))
            {
                //Move Backward (-)
                mover.Move(false);

            }

            if (Input.GetKey(KeyCode.D))
            {
                //Rotate Clockwise (+)
                mover.Rotate(true);

            }

            

        }

        if (controlType == ControlType.ArrowKeys)
        {

            if (Input.GetKey(KeyCode.W))
            {
                //Move Forward (+)
                mover.Move(true);

            }

            if (Input.GetKey(KeyCode.A))
            {
                //Move Backward (-)
                mover.Move(false);

            }

            if (Input.GetKey(KeyCode.S))
            {
                //Rotate CounterClockwise (-)
                mover.Rotate(false);

            }

            if (Input.GetKey(KeyCode.D))
            {
                //Rotate Clockwise (+)
                mover.Rotate(true);

            }


        }

    }
}
