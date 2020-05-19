using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrub : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("playerCollide", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("playerCollide", false);
        }
    }
}
