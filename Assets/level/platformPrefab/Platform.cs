﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour, FlowControll
{
    public Vector3 pivot;
    public Vector3 endTarget;
    public check platform = new check();
    private GameObject[] mushroom;

    public GameObject[] package;
    private void Awake()
    {
        foreach (Transform item in GetComponentsInChildren<Transform>())
        {

            if (item.tag == "startTarget")
            {
                pivot = new Vector3(item.localPosition.x, 0, 0);
            }
            if (item.tag == "target")
            {
                endTarget = new Vector3(item.localPosition.x, 0, 0);
            }
        }
        platform.last = false;
        platform.visibleEndPlatform = false;

        mushroom = new GameObject[2];
    }
    void Update()
    {
        movePlatform();
        checkCulling();
        endOfPlatformWhenVisible();
    }
    public struct check
    {
        public bool visibleEndPlatform;
        public bool last;
    }
    public void enablePlatform()
    {
        platform.last = true;
        gameObject.SetActive(true);
    }
    public void desablePlatform()
    {
        platform.last = false;
        platform.visibleEndPlatform = false;
        gameObject.SetActive(false);
        transform.localPosition = GetComponentInParent<SpawnPlatform>().pivot - new Vector3(pivot.x,0,0);
    }
    private void endOfPlatformWhenVisible()
    {
        if (platform.last)
            foreach (Transform item in GetComponentInChildren<Transform>())
            {
                float screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0)).x;
                if (item.gameObject.tag == "target")
                {
                    if (item.position.x <= screenWidth)
                    {
                        platform.visibleEndPlatform = true;
                    }
                }
            }
    }

    public void pause() { }
    public void resume() { }
    public void restart()
    {
        transform.position = new Vector3(-pivot.x, transform.position.y, 0);
    }
    public void dead() { }
    private void movePlatform()
    {
        Player p = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (!p.death && p.inGame)
        {
            transform.position -= new Vector3(Time.deltaTime * Progress.globalSpeed/2, 0, 0);
        }
    }
    public bool checkCulling()
    {
        int status = 0;
        foreach (Transform item in GetComponentInChildren<Transform>())
        {
            if (item.tag == "Untagged")
                status += System.Convert.ToInt32(item.GetComponent<Renderer>().enabled);
        }
        return (status == 0) ? true : false;
    }
    public void enableJumpEffect(int i)
    {
        foreach (Transform item in GetComponentInChildren<Transform>())
        {
            if (item.tag == "mushroomTriple")
            {
                mushroom[1] = item.gameObject;
            }
            if (item.tag == "mushroomDouble")
            {
                mushroom[0] = item.gameObject;
            }
        }
        if (i > 2 || i < 1)
        {
            return;
        }
        mushroom[i - 1].SetActive(true);
        foreach (GameObject item in package)
        {
            item.SetActive(false);
        }
        // package[i % package.Length].SetActive(true);
    }
    public void desableJumpEffect()
    {
        foreach (GameObject item in mushroom)
        {
            if (item)
                item.SetActive(false);
        }
    }
}


