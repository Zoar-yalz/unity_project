using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    private Animator animator;
    new private Rigidbody2D rigidbody;

    private float x_speed;
    private float y_speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        x_speed = 1F;
        y_speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v_speed = (transform.parent.right * x_speed + transform.parent.up * y_speed).normalized;
        rigidbody.velocity = v_speed * speed;
        if(x_speed==0&&y_speed==0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);

        }
        animator.SetFloat("y_speed", y_speed);
        animator.SetFloat("x_speed", x_speed);
    }
}
