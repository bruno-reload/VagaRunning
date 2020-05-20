using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culling : MonoBehaviour
{
    private void Update()
    {
        float width = GetComponent<SpriteRenderer>().size.x;
        
        float x = Camera.main.WorldToScreenPoint(transform.position + new Vector3(width/2, 0, 0)).x + 50;
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
