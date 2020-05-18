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
    public bool inGame = false;

    [HideInInspector]
    public bool onFloor = false;
    public bool dead = false;
    public bool readyToDie = false;
    private init dataStart;

    // jump factor float y = -4 * Mathf.Pow(Time.deltaTime % 1, 2) + 4 * (Time.deltaTime % 1);

    public struct init
    {
        public Vector3 pos;
        public Star start;
    }

    private void Start()
    {
        dataStart = new init();

        dataStart.pos = transform.position;

        speed = Progress.globalSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        animation = GetComponentInChildren<Animator>();
        childrenCollide = GetComponentInChildren<Collider2D>();
        animation.SetBool("start", true);
    }
    public void playerRun()
    {
        
        animation.SetBool("floor", true);
        animation.SetFloat("speedX", 1);
        inGame = true;
    }
    public void pause()
    {
        animation.enabled = false;
        rigidbody.simulated = false;
    }
    public void resume()
    {
        animation.enabled = true;
        rigidbody.simulated = true;
    }
    public void playerDead()
    {
        animation.SetBool("dead", true);
        animation.SetBool("floor", true);
        animation.SetFloat("speedY", 0);
        animation.SetFloat("speedX", 0);
        rigidbody.simulated = false;
        dead = true;
    }
    public void playerJump()
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
    public void aplicatioForce(float force = 1)
    {
        rigidbody.velocity = Vector2.up * force;
    }
    void FixedUpdate()
    {
        speed = Progress.globalSpeed;
        if (inGame)
        {
            if (!dead)
            {
                animation.SetBool("dead", false);
                if (onFloor)
                {
                    playerRun();
                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        aplicatioForce(speed);
                        onFloor = false;
                    }
                }
                if (!onFloor)
                {
                    playerJump();
                }
            }
            else
            {
                if (readyToDie)
                {
                    playerDead();
                }
            }
        }
    }
}
