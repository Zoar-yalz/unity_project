using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcCntroller : EnemyController
{
    GameObject player;
    Transform thistf, playertf;
    Rigidbody2D thisrb;

    StateManager statemanager;
    Vector3 point1, point2;//在point1和point2之间来回巡逻
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thistf = this.GetComponent<Transform>();
        thisrb = this.GetComponent<Rigidbody2D>();
        playertf = player.GetComponent<Transform>();

        statemanager = new StateManager();
        statemanager.RegionState("Idle");
        statemanager.RegionState("Chase");
        statemanager.SetDefaultState("Idle");

        point1 = new Vector3(5, 0, 0);
        point2 = new Vector3(-5, 0, 0);
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Chase();
        if ((player.transform.position - transform.position).magnitude < 1)
        {
            statemanager.ChangeState("Chase");
        }
        else
        {
            statemanager.ChangeState("Idle");
        }
        statemanager.KeepState(this);
    }

    
}


