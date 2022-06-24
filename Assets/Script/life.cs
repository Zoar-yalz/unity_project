using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public int life_num;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void receiveDamage(int damage)
    {
        life_num -= damage;


        if (life_num<=0)
        {
            animator.SetBool("isDead", true);
            Destroy(gameObject,0.6f);
            GameObject.Find("GameController").SendMessage("countkill");
        }
        else
        {
            animator.SetBool("isHurt", true);
        }
    }

}
