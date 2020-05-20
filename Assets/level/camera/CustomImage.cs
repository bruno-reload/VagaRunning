using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CustomImage : MonoBehaviour,FlowControll
{
    public Material effect;
    private Vector2 pos;
    private float radius;
    public Vector2 screen;
    public Texture inTexture;
    public float factorRadius = 1;
    private bool enable = true;
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, effect);
    }
    private void Start()
    {
        effect.SetFloat("_ActiveDeadEffect", 0);
        effect.SetVector("_PlayerPosition",Vector3.zero);
        radius = 1;
    }
    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.GetComponent<Player>().death)
        {

            Vector2 pos = player.GetComponent<Transform>().position;
            Vector2 playerOnScreen = Camera.main.WorldToViewportPoint(pos + new Vector2(0, 2 * Mathf.Abs(pos.y - transform.position.y)));

            effect.SetFloat("_ActiveDeadEffect", 1);
            effect.SetVector("_PlayerPosition", new Vector2(1 - playerOnScreen.x - 0.55f, playerOnScreen.y - 0.5f));
            effect.SetFloat("_Radius", radius);
            radius -= Time.deltaTime * factorRadius;
            if (radius <= .15f && enable)
            {
                radius = .15f;
                Invoke("stopwatch", 1);
            }
        }
        else
        {
            radius = 1;
            effect.SetFloat("_Radius", radius);
            enable = true;
        }
    }
    private void stopwatch()
    {
        enable = false;
    }
    
    public void pause(){}
    public void resume(){}
    public void restart(){
        
        effect.SetFloat("_ActiveDeadEffect", 0);
        effect.SetVector("_PlayerPosition",Vector3.zero);
        radius = 1;
    }
    public void dead(){}

}
