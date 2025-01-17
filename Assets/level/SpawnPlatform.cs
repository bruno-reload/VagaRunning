﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour, FlowControll
{
    public GameObject[] platformPool;
    private GameObject[] pool;
    private Vector3 startPos;
    private Vector3 endPos;
    public Vector3 pivot;
    private Coroutine aStarte;
    private int lastPlatform = -10;
    void Start()
    {
        pool = new GameObject[platformPool.Length];
        pivot = transform.position;
        for (int i = 0; i < platformPool.Length; i++)
        {
            pool[i] = Instantiate(platformPool[i]);
            pool[i].transform.SetParent(transform);
            pool[i].GetComponent<Platform>().desablePlatform();
        }

        aStarte = StartCoroutine("afterStart");
        startPos = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        endPos = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        transform.position = new Vector3(endPos.x, 0, 0);

    }
    IEnumerator afterStart()
    {
        yield return new WaitForEndOfFrame();
        int allDisconect = 0;
        foreach (GameObject item in pool)
        {
            if (!item.activeInHierarchy)
            {
                allDisconect++;
            }
        }
        if (allDisconect == platformPool.Length)
        {
            getInPool(pool[0].GetComponent<Platform>());
            allDisconect = 0;
        }
        StopCoroutine(aStarte);
    }
    public void restart()
    {
        for (int i = 0; i < platformPool.Length; i++)
        {
            pool[i].GetComponent<Platform>().desablePlatform();
        }
        getInPool(pool[0].GetComponent<Platform>());

    }
    bool hasElementPoolAvaliable()
    {
        int inactive = 0;
        foreach (GameObject element in pool)
        {
            if (!element.activeInHierarchy)
            {
                inactive++;
            }
        }
        if (inactive > 0)
        {
            return true;
        }
        return false;
    }
    private void Update()
    {
        foreach (GameObject item in pool)
        {
            Platform component = item.GetComponent<Platform>();
            if (component.platform.visibleEndPlatform)
            {

                if (hasElementPoolAvaliable() && component.platform.last)
                {
                    component.platform.last = false;

                    getInPool(component);
                }

                if (component.checkCulling())
                {
                    setInPool(item);
                }
            }
        }
    }
    private void setInPool(GameObject item)
    {
        item.transform.position = transform.position;
        item.GetComponent<Platform>().desablePlatform();

    }
    public void getInPool(Platform activePlatform)
    {
        int i = Random.Range(0, platformPool.Length);
        if (pool[i].activeInHierarchy)
        {
            getInPool(activePlatform);
            return;
        }
        else
        {

            pool[i].GetComponent<Platform>().enablePlatform();
            {
                Platform p = pool[i].GetComponent<Platform>();
                Vector3 pivotPlatform = p.pivot;
                Vector3 pos;
                int neo = Random.Range(0, 3);

                if (GameObject.FindWithTag("mushroomDouble") != null && GameObject.FindWithTag("mushroomTriple") != null)
                {
                    GameObject.FindWithTag("mushroomDouble").GetComponent<Mushroom>().gameObject.SetActive(false);
                    GameObject.FindWithTag("mushroomTriple").GetComponent<Mushroom>().gameObject.SetActive(false);
                }

                activePlatform.enableJumpEffect(neo - lastPlatform);
                pool[i].GetComponent<Platform>().desableJumpEffect();

                float endPlatform = Mathf.Abs(p.endTarget.x - transform.position.x) / 2;

                pos = new Vector3((Mathf.Sqrt(Progress.globalSpeed) / Mathf.Abs(Physics2D.gravity.y)) - 4, startPos.y + 2.8f * (endPos.y / 3) * neo, 0);
                pool[i].GetComponent<Transform>().position += pos;

                lastPlatform = neo;
            }
        }
        return;
    }
    public void dead() { }
    public void pause()
    {
        if (pool == null)
        {
            return;
        }
        foreach (GameObject item in pool)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Platform>().pause();
            }
        }
    }
    public void resume()
    {
        foreach (GameObject item in pool)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Platform>().resume();
            }
        }
    }
}
