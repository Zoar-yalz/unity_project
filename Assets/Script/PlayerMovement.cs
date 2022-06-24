using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    new private Rigidbody2D rigidbody;
    private Animator animator;
    private float inputX, inputY;
    private float stopX, stopY;

    public GameObject arrow;

    float shootTime = 0.5F;
    float coolTime = 0F;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stopX = 1;
        stopY = 0;
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Vector2 input = (transform.right * inputX + transform.up * inputY).normalized;
        rigidbody.velocity = input * speed;

        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);
        coolTime += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") == 1)
        {
            if (coolTime >= shootTime)
            {
                GameObject newArrow = Instantiate(arrow);
                Vector2 direction = (transform.right * stopX + transform.up * stopY).normalized;
                newArrow.GetComponent<castBehaviour>().init(direction, rigidbody.transform.position);
                coolTime = 0F;
            }
        }
    }
    public void setSpeed(float sp)
    {
        speed = sp;
    }
}
