using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deep : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
    }
}
