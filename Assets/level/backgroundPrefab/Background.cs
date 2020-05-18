using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Background : MonoBehaviour
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
        status = false;
    }
    public void resume()
    {
        status = false;
    }
    void Update()
    {
        if (status)
        {
            renderer.material.SetFloat("_H", Progress.globalSpeed / 20);
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
