using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public float speed;
    public static float globalSpeed;
    public float timeStep;

    private void Start()
    {
        globalSpeed = speed;
        InvokeRepeating("updateTime", 0,timeStep);
    }
    private void updateTime()
    {
        globalSpeed++;

    }
}
