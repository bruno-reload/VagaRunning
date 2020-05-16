using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float force;
    public void AnimationComplete()
    {
        GetComponentInChildren<Animator>().SetBool("jump", false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Mathf.Sign(other.GetComponent<Rigidbody2D>().velocity.y) < 0)
            {
                GetComponentInChildren<Animator>().SetBool("jump", true);
                other.GetComponent<Rigidbody2D>().velocity = Vector3.up * Progress.globalSpeed * force;
            }
        }
    }
}
