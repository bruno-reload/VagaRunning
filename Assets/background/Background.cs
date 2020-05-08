using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Background : MonoBehaviour
{
    public Player player;
    public static float speedFactor = 5;
    [HideInInspector]
    private new Renderer renderer;
    private float x = 0;
    private float y = 0;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.onFloor)
            x = 0.0f;
        else
        {
            if (player.rigidbody.velocity.y > 0)
            {
                x += Time.deltaTime;
            }
            if (player.rigidbody.velocity.y < 0)
            {
                x -= Time.deltaTime;
            }
        }
        renderer.material.SetFloat("_V", -4 * Mathf.Pow(x, 2) + 4 * x);
    }
}
