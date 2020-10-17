using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : Controller
{

    public enum ControlType { WASD, ArrowKeys, Controller1, Controller2 };
    public ControlType controlType;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.players.Add(this);

        
    }

    public void OnDestroy()
    {
        GameManager.instance.players.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToMove = Vector3.zero;

        if(controlType == ControlType.WASD)
        {

            if (Input.GetKey(KeyCode.W))
            {
                //Move Forward (+)
                directionToMove = data.transform.forward;

            }

            if (Input.GetKey(KeyCode.A))
            {
                //Rotate CounterClockwise (-)
               data.mover.Rotate(false);

            }

            if (Input.GetKey(KeyCode.S))
            {
                //Move Backward (-)
                directionToMove = -data.transform.forward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                //Rotate Clockwise (+)
                data.mover.Rotate(true);

            }

            if (Input.GetKey(KeyCode.Space))
            {
                UnityEngine.Debug.Log("Firing Cannon");
                data.mover.Shoot();

            }

            data.mover.Move(directionToMove);

        }

        if (controlType == ControlType.ArrowKeys)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Move Forward (+)
                directionToMove = data.transform.forward;

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Rotate CounterClockwise (-)
                data.mover.Rotate(false);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Move Backward (-)
                directionToMove = -data.transform.forward;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Rotate Clockwise (+)
                data.mover.Rotate(true);

            }

            if (Input.GetKey(KeyCode.L))
            {
                UnityEngine.Debug.Log("Firing Cannon");
                data.mover.Shoot();

            }

            data.mover.Move(directionToMove);
        }

        if (controlType == ControlType.Controller1)
            {

            if (Input.GetAxis("Vertical") > 0.5)
            {
                //Move Forward (+)
                directionToMove = data.transform.forward;

            }

            if (Input.GetAxis("Horizontal") < -0.5)
            {
                //Rotate CounterClockwise (-)
                data.mover.Rotate(false);

            }

            if (Input.GetAxis("Vertical") < -0.5)
            {
                //Move Backward (-)
                directionToMove = -data.transform.forward;
            }

            if (Input.GetAxis("Horizontal") > 0.5)
            {
                //Rotate Clockwise (+)
                data.mover.Rotate(true);

            }

            if (Input.GetAxis("Fire1") > 0.5)
            {

                UnityEngine.Debug.Log("Firing Cannon");
                data.mover.Shoot();

            }

            data.mover.Move(directionToMove);

        }
    }
}
