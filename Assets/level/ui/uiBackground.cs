using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiBackground : MonoBehaviour
{
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // Material cam = GameObject.FindWithTag("MainCamera").GetComponent<Renderer>().material;
        // Graphics.Blit(GetComponent<Renderer>().material.mainTexture, Camera.main.activeTexture, GetComponent<Renderer>().material);
    }
}
