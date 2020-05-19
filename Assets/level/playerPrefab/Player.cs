using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Player : MonoBehaviour, FlowControll
{
    public float speed = 0;
    [HideInInspector]
    public new Rigidbody2D rigidbody;
    private new Animator animation;
    public Coroutine corrotine { get; private set; }
    private Collider2D childrenCollide;
    private bool inGame = false;

    [HideInInspector]
    public bool onFloor = false;
    public bool death = false;
    public bool readyToDie = false;
    private init dataStart;
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
        animation.enabled = true;
    }
    private void playerRun()
    {
        animation.SetBool("floor", true);
        animation.SetFloat("speedX", 0.5f);
        Invoke("normalizeAnimationSpeed", 1);
    }
    private void normalizeAnimationSpeed()
    {
        animation.SetFloat("speedX", 1);
    }
    public void pause()
    {
        if (!animation)
        {
            animation = GetComponentInChildren<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
        }
        animation.enabled = false;
        rigidbody.simulated = false;

        inGame = false;
    }
    public void resume()
    {
        animation.enabled = true;
        rigidbody.simulated = true;
        inGame = true;
        death = false;
        playerRun();
    }
    public void playerDead()
    {
        rigidbody.simulated = false;
        death = true;
        Invoke("lateDead", 0.6f);
    }
    private void lateDead()
    {
        animation.SetBool("dead", true);
        animation.SetBool("floor", true);
        animation.SetFloat("speedY", 0);
        animation.SetFloat("speedX", 0);
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
    public void restart()
    {
        transform.position = new Vector3(0,1.9f,0);
    }

    public void dead() { }
    public void aplicatioForce(float force = 1)
    {
        rigidbody.velocity = Vector2.up * force;
    }
    void FixedUpdate()
    {
        speed = Progress.globalSpeed;
        if (inGame)
        {
            if (!death)
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
