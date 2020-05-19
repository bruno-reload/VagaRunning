using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, FlowControll
{
    private Player p;
    private bool contact = false;
    private Vector3 defalPosition;
    private float imageSizeX;
    private void Start()
    {
        defalPosition = transform.localPosition;
        p = GameObject.FindWithTag("Player").GetComponent<Player>();
        imageSizeX = GetComponent<SpriteRenderer>().size.x;
    }
    private void Update()
    {
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x - imageSizeX)
        {
            dead();
        }
        if (!p.death && p.inGame && contact)
        {
            transform.position -= new Vector3(Time.deltaTime * Progress.globalSpeed / 2, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "deep")
        {
            contact = true;
        }
    }
    public void pause()
    {
        GetComponent<Rigidbody2D>().simulated = false;
    }
    public void resume()
    {

        GetComponent<Rigidbody2D>().simulated = true;
    }
    public void restart()
    {
        gameObject.SetActive(true);
    }
    public void dead()
    {
        gameObject.SetActive(false);
        transform.localPosition = default;
    }
}
