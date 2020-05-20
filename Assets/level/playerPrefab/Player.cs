using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Player : MonoBehaviour, FlowControll
{
    private float speed = 0;
    [HideInInspector]
    public new Rigidbody2D rigidbody;
    private new Animator animation;
    public Coroutine corrotine { get; private set; }
    private Collider2D childrenCollide;
    [HideInInspector]
    public bool inGame = false;
    private UiManege uiManege;

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
        uiManege = GameObject.FindWithTag("interface").GetComponent<UiManege>();
    }
    private void run()
    {
        animation.SetFloat("speedX", 1);
    }
    public void walke()
    {
        animation.SetFloat("speedX", .5f);
        Invoke("run", 1f);
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
        run();
    }
    private void lateDead()
    {
        animation.SetBool("dead", true);
        animation.SetBool("floor", true);
        animation.SetFloat("speedY", 0);
        animation.SetFloat("speedX", 0);
    }
    public void jump()
    {
        if (rigidbody.velocity.y > 0)
        {
            animation.SetFloat("speedY", 1);
        }
        else
        {
            animation.SetFloat("speedY", -1);
        }
    }
    public void restart()
    {
        animation.SetBool("dead", false);
        transform.position = new Vector3(0, 1.9f, -4);
        walke();
    }

    public void dead()
    {
        rigidbody.simulated = false;
        death = true;
        Invoke("lateDead", 0.6f);
    }
    void FixedUpdate()
    {
        if (inGame)
        {
            if (!death)
            {
                if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x)
                {
                    uiManege.dead();
                }
                if (onFloor)
                {
                    animation.SetBool("floor", true);
                    walke();
                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        rigidbody.AddForce(Vector2.up * speed * 40);
                        onFloor = false;
                    }
                }
                if (!onFloor)
                {
                    animation.SetBool("floor", false);
                    jump();
                }
            }
            else
            {
                if (readyToDie)
                {
                    dead();
                }
            }
        }
    }
}
