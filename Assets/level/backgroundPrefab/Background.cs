using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Background : MonoBehaviour, FlowControll
{
    private Player player;
    public float speedFactor;
    [HideInInspector]
    private new Renderer renderer;
    private float y = 0;
    private bool status = false;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void pause()
    {
        if (!renderer)
        {
            renderer = GetComponent<Renderer>();
        }
        renderer.material.SetFloat("_Stop", 0);
        status = false;
    }
    public void resume()
    {
        renderer.material.SetFloat("_Stop", 1);
        status = false;
    }
    void Update()
    {
        if (status)
        {
            renderer.material.SetFloat("_H",Mathf.Lerp(renderer.material.GetFloat("_H"),1,0.001f));
            float VDirection = Mathf.Sign(player.rigidbody.velocity.y);
            if (player.onFloor)
                y = 0.0f;
            else
            {
                if (VDirection > 0)
                {
                    y += Time.deltaTime;
                }
                if (VDirection < 0)
                {
                    y -= Time.deltaTime;
                }
                renderer.material.SetFloat("_V", Mathf.Lerp(renderer.material.GetFloat("_V"), VDirection, speedFactor * Time.deltaTime));
            }

            if (GameObject.FindWithTag("Player").GetComponent<Player>().dead)
            {
                renderer.material.SetFloat("_Stop", 0);
            }
        }
    }
}
