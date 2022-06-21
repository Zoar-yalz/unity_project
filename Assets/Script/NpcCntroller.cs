using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcCntroller : MonoBehaviour
{
    GameObject player;
    Transform thistf, playertf;
    Rigidbody2D thisrb;

    StateManager statemanager;
    Vector3 point1, point2;//在point1和point2之间来回巡逻
    public bool target;//true表示点2为目标，false表示点1
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

    public void Chase()
    {
        thisrb.velocity = Vector3.Normalize(playertf.position - thistf.position) * 2f;
    }

    public void Idle()
    {
        //如果不在原有路径，则先返回（0，0，0）
        

        if (target)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            target = this.transform.position.x < point1.x;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * moveSpeed, 0);
            target = this.transform.position.x <= point2.x;
        }
    }
}



//abstract class State
public abstract class State
{
    public string stateType;
    public bool stateOn;

    public State()
    {
        stateOn = false;
    }
    public abstract void EnterState();
    public abstract void UpdateState(NpcCntroller enemy);
    public abstract void ExitState();
}

//巡逻状态
public class IdleState : State
{
    public IdleState() : base()
    {
        stateType = "Idle";
    }

    public override void EnterState()
    {
        stateOn = true;
    }

    public override void UpdateState(NpcCntroller enemy)
    {
        enemy.Idle();
    }

    public override void ExitState()
    {
        stateOn = false;
    }

}

public class ChaseState : State
{
    public ChaseState() : base()
    {
        stateType = "Chase";
    }

    public override void EnterState()
    {
        stateOn = true;
    }

    public override void UpdateState(NpcCntroller enemy)
    {
        enemy.Chase();
    }

    public override void ExitState()
    {
        stateOn = false;
    }
}


//创建状态
public class StateCreator
{
    public State CreateState(string type)
    {
        switch (type)
        {
            case "Idle":
                return new IdleState();
            case "Chase":
                return new ChaseState();
        }
        return null;
    }
}

public class StateManager
{
    State currentState;
    State defaultState;
    Dictionary<string, State> regioned;//存放状态

    public StateManager()
    {
        regioned = new Dictionary<string, State>();
        currentState = null;
        defaultState = null;
    }

    //选择一个状态作为默认状态
    public void SetDefaultState(string stateName)
    {
        if (!regioned.ContainsKey(stateName))
        {
            return;
        }
        defaultState = regioned[stateName];
        currentState = defaultState;
    }

    //添加需要的状态
    public void RegionState(string stateName)
    {
        if (regioned.ContainsKey(stateName))
        {
            return;
        }
        regioned.Add(stateName, new StateCreator().CreateState(stateName));
    }

    //状态切换
    public void ChangeState(string stateName)
    {
        if (!regioned.ContainsKey(stateName))
        {
            return;
        }
        currentState.ExitState();
        currentState = regioned[stateName];
        currentState.EnterState();
    }

    //状态进行
    public void KeepState(NpcCntroller enemy)
    {
        if (currentState != null)
        {
            currentState.UpdateState(enemy);
        }
    }
}
