﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CustomImage : MonoBehaviour
{
    public Material effect;
    private Vector2 pos;
    private float radius;
    private Vector2 screen;
    public float factorRadius = 1;
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, effect);
    }
    private void Start()
    {
        effect.SetFloat("_ActiveDeadEffect", 0);
        radius = 1;
    }
    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player>().dead)
        {

            Vector2 pos = player.GetComponent<Transform>().position;
            Vector2 playerOnScreen = Camera.main.WorldToViewportPoint(pos + new Vector2(0, 2 * Mathf.Abs(pos.y - transform.position.y)));

            effect.SetFloat("_ActiveDeadEffect", 1);
            effect.SetVector("_PlayerPosition", new Vector2(1 - playerOnScreen.x - 0.55f, playerOnScreen.y - 0.5f));
            effect.SetFloat("_Radius", radius);
            radius -= Time.deltaTime * factorRadius;
            if (radius <= .15f)
            {
                radius = .15f;

                player.GetComponent<Player>().readyToDie = true;
            }
        }
        else
        {
            effect.SetFloat("_Radius", radius);
        }
    }

}
