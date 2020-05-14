using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Vector2 playerPos;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, playerPos.y, Time.deltaTime),-10);
    }
}
