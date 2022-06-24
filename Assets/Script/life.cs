using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public int life_num;
    private Animator animator;
    GameObject npc;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
         

    }

    void Update()
    {
       /* if ((npc.transform.position - transform.position).magnitude < 0.25)
        {
            time += Time.deltaTime;
            if(time>=0.5f)
            {
                receiveDamage(1);
                time = 0;
            }
            
            //Sleep(500);
            //statemanager.ChangeState("Chase");
        }*/
    }

    public void receiveDamage(int damage)
    {
        life_num -= damage;


        if (life_num<=0)
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject,0.6f);
        }
        else
        {
            animator.SetBool("isHurt", true);
        }
    }
    public void getDamage()
    {
        life_num -= 10;


        if (life_num <= 0)
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject, 0.6f);
        }
        else
        {
            animator.SetBool("isHurt", true);
        }
    }
}
