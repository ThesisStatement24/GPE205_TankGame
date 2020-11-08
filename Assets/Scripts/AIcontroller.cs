using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : Controller
{

    public TankData Data;
    public List<Transform> waypoints;
    public int currentWaypointIndex = 0;
    public float closeEnoughForWaypoints = 0.1f;
    public enum PatrolType { Stop, Loop, PingPong, Random };
    public PatrolType patrolType;
    public bool isPatrolling = true;
    public bool isPatrolForward = true;

    public enum AIStates {Idle, Spin, AttackPlayer};
    public AIStates currentState = AIStates.Idle;
    public enum AIAvoidanceState {Normal, TurnToAvoid, MoveToAvoid};
    public AIAvoidanceState currentAvoidState;
    public float lastStateChangeTime;
    public float lastAvoidanceStateChangeTime;

    public float fieldOfView = 60.0f;
    public float viewDistance = 10.0f;
    public float hearingSensitivity = 1.0f;
    public GameObject target;

    

    public virtual void Update()
    {  

        if(data.health <= 0)
        {

            Destroy(this.gameObject);

        }
        
    }

    public void ChangeState(AIStates newState) {
        currentState = newState;

        lastStateChangeTime = Time.time;
    }

    public void ChangeAvoidanceState(AIAvoidanceState newState)
    {
        currentAvoidState = newState;

        lastAvoidanceStateChangeTime = Time.time;
    }

    public bool CanMoveForward(float distance)
    {

        return !Physics.Raycast(data.transform.position, data.transform.forward, distance);

    }

    public bool CanSee(GameObject target) {

        Vector3 vectorToTarget = target.transform.position - data.transform.position;

        float angle = Vector3.Angle(data.transform.forward, vectorToTarget);

        if (angle > fieldOfView)
        {

            return false;

        }

        RaycastHit hitInfo;

        if (Physics.Raycast(data.transform.position, data.transform.forward, out hitInfo, viewDistance))
        {

            if (hitInfo.collider.gameObject != target)
            {

                return false;
            }

        }

        return true;
    }

    public bool CanHear(GameObject target)
    {

        if(Vector3.Distance(target.transform.position, transform.position) < hearingSensitivity)
        {

            return true;
        }

        return false;
    }

    public void DoAttackPlayer()
    {
        DoTargetPlayer();
        DoAttackTarget();
    }

    public void DoTargetPlayer()
    {
        target = GameManager.instance.players[0].data.gameObject;
    }

    public void DoAttackTarget()
    {
        if (target != null)
        {
            data.mover.MoveTo(target.transform);

            data.mover.Shoot();
        }

    }

    public void DoLeadAttackTarget()
    {


    }

    public void DoIdle()
    {


    }

    public void DoSpin()
    {
        data.mover.Rotate(true);

    }

    public void DoShoot()
    {
        data.mover.Shoot();

    }

    public void DoFindNearestHealthPack()
    {


    }

    public void DoPatrol()
    {
        
        if (currentAvoidState == AIAvoidanceState.Normal)
        {
            //Turn towards our waypoint and Move forward
            data.mover.MoveTo(waypoints[currentWaypointIndex].transform);

            //if we are "close enough" to the waypoint, advance to the next waypoint
            if (Vector3.Distance(data.transform.position, waypoints[currentWaypointIndex].transform.position) <= closeEnoughForWaypoints)
            {
                if (isPatrolForward)
                {
                    currentWaypointIndex = currentWaypointIndex + 1;
                }
                else
                {
                    currentWaypointIndex = currentWaypointIndex - 1;
                }


            }

            //Loop
            if (currentWaypointIndex >= waypoints.Count)
            {
                if (patrolType == PatrolType.Loop)
                {
                    currentWaypointIndex = 0;
                }
                else if (patrolType == PatrolType.Random)
                {
                    currentWaypointIndex = Random.Range(0, waypoints.Count);
                }
                else if (patrolType == PatrolType.Stop)
                {
                    isPatrolling = false;
                }
                else if (patrolType == PatrolType.PingPong)
                {
                    isPatrolForward = !isPatrolForward;
                    currentWaypointIndex = Mathf.Clamp(currentWaypointIndex, 1, waypoints.Count - 1);
                }


            }
        }

    }

}
