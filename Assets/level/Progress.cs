using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour, FlowControll
{
    public float speed;
    public static float globalSpeed;
    private float speedDefault;
    private bool paused = false;
    public float timeStep;

    private void Start()
    {
        globalSpeed = speed;
        InvokeRepeating("updateTime", 0, timeStep);
        speedDefault = speed;
    }
    private void updateTime()
    {
        if (!paused)
            globalSpeed++;
    }
    public void restart()
    {
        globalSpeed = speedDefault;
    }
    public void pause()
    {
        paused = true;
    }
    public void resume()
    {
        paused = false;
    }
    public void dead() {; }
}
