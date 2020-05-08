using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGrid : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 size;
    private int[,] cell;
    void Start()
    {
        cell = new int[(int) size.x, (int) size.y];
        Debug.Log((Screen.height + (Screen.height / 2)));
        // Debug.Log(cell.GetLength(0));
    }

    // Update is called once per frame
    void Update()
    {   

    }
}
