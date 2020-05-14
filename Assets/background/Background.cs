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
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        if (!player.onFloor)
            renderer.material.SetFloat("_V", Mathf.Lerp(0, -Mathf.Sign(player.rigidbody.velocity.y), Time.deltaTime * speedFactor));
    }
}
