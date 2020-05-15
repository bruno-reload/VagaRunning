using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 pivot;
    public ArrayList endTarget;
    public check platform = new check();
    private void Awake()
    {
        endTarget = new ArrayList();
        foreach (Transform item in GetComponentsInChildren<Transform>())
        {

            if (item.tag == "startTarget")
            {
                pivot = new Vector3(item.localPosition.x, 0, 0);
            }
            if (item.tag == "target")
            {
                endTarget.Add(item);
            }
        }
        platform.last = false;
        platform.visibleEndPlatform = false;
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
        transform.position = GetComponentInParent<Transform>().position + pivot;
    }
    private void endOfPlatformWhenVisible()
    {
        if (platform.last)
            foreach (Transform item in GetComponentInChildren<Transform>())
            {
                if (item.gameObject.tag == "target")
                {
                    float screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0)).x;
                    if (item.position.x <= screenWidth)
                    {
                        platform.visibleEndPlatform = true;
                    }
                }
                // if (item.gameObject.tag == "firstTarget")
                // {
                // }
            }
    }
    private void movePlatform()
    {
        transform.position -= new Vector3(Time.deltaTime * Progress.globalSpeed / 2, 0, 0);
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
}


