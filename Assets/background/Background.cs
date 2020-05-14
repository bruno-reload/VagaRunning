﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Background : MonoBehaviour
{
    public Player player;
    public static float speedFactor = 5;
    [HideInInspector]
    private new Renderer renderer;
    private float y = 0;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.onFloor)
            y = 0;
        else
        {
            if (player.rigidbody.velocity.y > 0)
            {
                y += Time.deltaTime;
            }
            if (player.rigidbody.velocity.y < 0)
            {
                y -= Time.deltaTime;
            }
        }
        renderer.material.SetFloat("_V", Mathf.Lerp(0, Mathf.Sign(player.rigidbody.velocity.y), y));
    }
}
