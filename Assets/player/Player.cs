using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Player : MonoBehaviour
{
    private Vector2 direction;
    private new Rigidbody2D rigidbody;
    private float speedRun;
    private float gravity;
    private float speedWalk;
    public Coroutine corrotine { get; private set; }

    // jump factor float y = -4 * Mathf.Pow(Time.deltaTime % 1, 2) + 4 * (Time.deltaTime % 1);
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gravity = 9.8f;
    }
    void FixedUpdate()
    {
        Debug.Log(Input.GetButton("Fire1"));
        if (Input.GetButtonDown("Fire1"))
        {
            // corrotine = jump();
            // StartCoroutine(corrotine);
        }
        // velocity.y -= Time.fixedTime;
        direction.y = -gravity;
        rigidbody.MovePosition(direction);
    }

    IEnumerable jump()
    {

        Debug.Log("foi");
        float x = 0;
        while (x <= 1 / 2)
        {
            x += Time.deltaTime;
            direction.y = -4 * Mathf.Pow(x, 2) + 4 * (x) * 1000;
            Debug.Log(-4 * Mathf.Pow(x, 2) + 4 * (x) * 1000);
            yield return null;
        }
    }
}
