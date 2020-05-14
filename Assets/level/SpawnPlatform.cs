using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject[] platformPool;
    private GameObject[] pool;
    private Coroutine aStarte;
    private float timeJump;
    void Start()
    {
        pool = new GameObject[platformPool.Length];
        for (int i = 0; i < platformPool.Length; i++)
        {
            pool[i] = Instantiate(platformPool[i]);
            pool[i].transform.position = transform.position;
            pool[i].SetActive(false);
            pool[i].transform.SetParent(transform);
        }

        aStarte = StartCoroutine("afterStart");
        timeJump = Progress.globalSpeed / Physics2D.gravity.y;
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
            getInPool();
            allDisconect = 0;
        }
        StopCoroutine(aStarte);
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
                    getInPool();
                }
                if(component.checkCulling())
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
    public void getInPool()
    {
        int i = Random.Range(0, platformPool.Length);
        if (pool[i].activeInHierarchy)
        {
            getInPool();
            return;
        }
        else
        {
            pool[i].GetComponent<Platform>().enablePlatform();
            {
                Platform plataform = pool[i].GetComponent<Platform>();

                float endPlatform = 0;

                foreach (Transform item in plataform.targets)
                {
                    if (item.gameObject.tag == "target")
                    {
                        endPlatform = Mathf.Abs(item.localPosition.x);
                    }
                }
                float start = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
                float end = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight)).y;

                // Progress.globalSpeed * Time.deltaTime +

                Vector3 pos = new Vector3(endPlatform, start + (end / 4) * Random.Range(0, 0) - plataform.basePosition.y, 0);

                pool[i].GetComponent<Transform>().position = pos;
            }
        }
        return;
    }
}
