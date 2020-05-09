using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    public bool left;
    public bool right;
    public bool up;
    public bool down;
    public bool leftUp;
    public bool leftDown;
    public bool righttUp;
    public bool rightDown;


    [HideInInspector]
    public byte mask;
    public bool start;
    [HideInInspector]
    public Vector2 pos;

    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    public byte getMask()
    {
        setMask();
        return mask;
    }
    private void setMask()
    {
        int value = 0;
        value = System.Convert.ToInt32(left) * 1 +
                System.Convert.ToInt32(right) * 2 +
                System.Convert.ToInt32(up) * 4 +
                System.Convert.ToInt32(down) * 8 +
                System.Convert.ToInt32(leftUp) * 16 +
                System.Convert.ToInt32(leftDown) * 32 +
                System.Convert.ToInt32(righttUp) * 64 +
                System.Convert.ToInt32(rightDown) * 128;

        try
        {
            mask = (byte)value;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            throw;
        }
    }
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
