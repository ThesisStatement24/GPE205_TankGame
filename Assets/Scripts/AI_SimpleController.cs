using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_SimpleController : AIcontroller
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        //Finite State Machine
        switch (currentState)
        {

            case AIStates.Idle:

                DoTargetPlayer();
                DoIdle();

                if (CanSee(target))
                {

                    ChangeState(AIStates.AttackPlayer);

                }

                if (CanHear(target))
                {

                    ChangeState(AIStates.Spin);

                }
                break;

            case AIStates.Spin:

                DoTargetPlayer();
                DoSpin();

                if (CanSee(target))
                {

                    ChangeState(AIStates.AttackPlayer);

                }

                
                break;

            case AIStates.AttackPlayer:

                DoAttackPlayer();

                if (!CanSee(target))
                {

                    ChangeState(AIStates.Spin);

                }

                
                break;

            default:
                //If we get here, something is horribly wrong
                ChangeState(AIStates.Idle);
                break;
        }
    }
}
