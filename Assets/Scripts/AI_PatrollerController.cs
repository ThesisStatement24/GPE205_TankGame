using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_PatrollerController : AIcontroller
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemies.Add(this);


    }

    public void OnDestroy()
    {
        GameManager.instance.enemies.Remove(this);
    }

    // Update is called once per frame
    public override void Update()
    {

        DoPatrol();
        
    }
}
