﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Vector2 playerPos;
    public float lerpFactor = 1;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, playerPos.y, lerpFactor * Time.deltaTime), -10);
    }
}
