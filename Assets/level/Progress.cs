using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public float speed;
    public static float globalSpeed;

    private void Update()
    {
        globalSpeed = speed;
    }
}
