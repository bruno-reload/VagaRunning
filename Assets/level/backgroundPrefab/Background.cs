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
        renderer.material.SetFloat("_H", 0);
    }

    public void pause()
    {
        status = false;
    }
    public void resume()
    {
        status = true;
    }
    public void restart()
    {
        resume();
    }
    public void dead()
    {
        pause();
    }
    void Update()
    {
        if (status)
        {
            float VDirection = Mathf.Sign(player.rigidbody.velocity.y);
            renderer.material.SetFloat("_H", Mathf.Lerp(renderer.material.GetFloat("_H"), 1, 0.005f * Time.deltaTime));
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
        }
        else
        {
            renderer.material.SetFloat("_H", 0);
        }
    }
}
