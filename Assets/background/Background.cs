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
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(renderer.material.GetFloat("Up"));
        // Debug.Log(Mathf.Clamp(player.rigidbody.velocity.y,0,1));
        // renderer.material.SetFloat("Up",Mathf.Clamp(player.rigidbody.velocity.y,0,1));
    }
}
