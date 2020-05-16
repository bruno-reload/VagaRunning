using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culling : MonoBehaviour
{
    private void Update()
    {
        float x = Camera.main.WorldToScreenPoint(transform.position).x + GetComponent<SpriteRenderer>().sprite.rect.width;
        if (x < 0)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
