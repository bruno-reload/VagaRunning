using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject[] platformPool;
    private GameObject[] pool;
    private Vector3 startPos;
    private Vector3 endPos;
    private Coroutine aStarte;
    private float timeJump;
    private int lastPlatform = -10;
    void Start()
    {
        pool = new GameObject[platformPool.Length];
        for (int i = 0; i < platformPool.Length; i++)
        {
            pool[i] = Instantiate(platformPool[i]);
            pool[i].SetActive(false);
            pool[i].transform.SetParent(transform);
            pool[i].transform.position = platformPool[i].GetComponent<Platform>().pivot + transform.position;
        }

        aStarte = StartCoroutine("afterStart");
        timeJump = 0;
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
            getInPool(transform.position);
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
                    getInPool(item.transform.position);
                }

                if (component.checkCulling())
                {
                    setInPool(item);
                }
            }

        }
    }
    private bool distanceMaxToJump()
    {
        return true;
    }
    private void setInPool(GameObject item)
    {
        item.transform.position = transform.position;
        item.GetComponent<Platform>().desablePlatform();

    }
    public void getInPool(Vector3 activePlatform)
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
                // Platform plataform = pool[i].GetComponent<Platform>();

                // float endPlatform = 0;

                // foreach (Transform item in plataform.targets)
                // {
                //     endPlatform = Mathf.Abs(item.localPosition.x);

                // }

                // Progress.globalSpeed * Time.deltaTime +

                Vector3 pivotPlatform = pool[i].GetComponent<Platform>().pivot;
                int r = Random.Range(0, 3);
                Vector3 pos;
                if (r - lastPlatform == 2)
                {
                    Debug.Log("tripleJump");
                }
                if (r - lastPlatform == 1)
                {
                    Debug.Log("doubleJump");
                }
                if ((r - lastPlatform == 0))
                {
                    Debug.Log("Jump");
                }

                pos = new Vector3(pivotPlatform.x + Mathf.Abs(Physics2D.gravity.y), startPos.y + 2.8f * (endPos.y / 3) * r, 0);
                pool[i].GetComponent<Transform>().position += pos;

                lastPlatform = r;
            }
        }
        return;
    }
}
