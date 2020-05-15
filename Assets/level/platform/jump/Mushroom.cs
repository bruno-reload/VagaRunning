using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int force;

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<Animator>().SetBool("jump", true);
            other.GetComponent<Rigidbody2D>().velocity = Vector3.up * Progress.globalSpeed * force;
        }
    }
}
