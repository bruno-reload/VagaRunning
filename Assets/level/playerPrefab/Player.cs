using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Player : MonoBehaviour
{
    public float speed = 0;
    [HideInInspector]
    public new Rigidbody2D rigidbody;
    private new Animator animation;
    public Coroutine corrotine { get; private set; }
    private Collider2D childrenCollide;

    [HideInInspector]
    public bool onFloor = false;
    public bool dead = false;
    public bool readyToDie = false;

    // jump factor float y = -4 * Mathf.Pow(Time.deltaTime % 1, 2) + 4 * (Time.deltaTime % 1);
    private void Start()
    {
        speed = Progress.globalSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponentInChildren<Animator>();
        childrenCollide = GetComponentInChildren<Collider2D>();
        animation.SetBool("start", true);
    }
    void FixedUpdate()
    {
        speed = Progress.globalSpeed;
        if (!dead)
        {
            animation.SetBool("dead", false);
            if (onFloor)
            {
                animation.SetBool("floor", true);
                animation.SetFloat("speedX", 1);
                if (Input.GetKeyUp(KeyCode.A))
                {
                    rigidbody.velocity = Vector2.up * speed;
                    onFloor = false;
                }
            }
            if (!onFloor)
            {
                animation.SetBool("floor", false);
                if (rigidbody.velocity.y < 0)
                {
                    animation.SetFloat("speedY", -1);
                }
                if (rigidbody.velocity.y > 0)
                {
                    animation.SetFloat("speedY", 1);
                }
            }
        }
        else
        {
            if (readyToDie)
            {
                animation.SetBool("dead", true);
                animation.SetBool("floor", true);
                animation.SetFloat("speedY", 0);
                animation.SetFloat("speedX", 0);
                rigidbody.simulated = false;
            }
        }
    }
}
