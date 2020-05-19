using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBackground : MonoBehaviour, FlowControll
{
    private Material bk;
    public float transictionSpeed = 1;
    public bool status;
    private void Start()
    {
        bk = GetComponent<Image>().material;
        bk.SetFloat("_Slide", 0);
        status = false;
    }

    private void Update()
    {
        if (status)
        {
            bk.SetFloat("_Slide", Mathf.Lerp(bk.GetFloat("_Slide"), 2, transictionSpeed * Time.deltaTime));
            if (bk.GetFloat("_Slide") >= 2f)
            {
                pause();
            }
        }
    }
    public void restart()
    {
        bk.SetFloat("_Slide", 0);
    }
    public void transition()
    {
        status = false;
    }
    public void resume()
    {
        status = true;
    }
    public void pause()
    {
        status = false;
    }
    public void dead() { }
}
