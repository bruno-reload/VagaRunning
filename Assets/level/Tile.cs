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

    public Vector2 upDirection;

    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
