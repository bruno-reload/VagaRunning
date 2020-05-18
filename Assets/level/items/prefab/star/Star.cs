using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindWithTag("interface").GetComponent<UiManege>().addStar();
            animator.SetBool("collected", true);
        }
    }
    public void desable()
    {
        gameObject.SetActive(false);
    }
    public void enable()
    {
        animator.SetBool("collected", false);
        gameObject.SetActive(true);
    }
}
