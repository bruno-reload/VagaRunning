using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            GameObject.FindWithTag("interface").GetComponent<UiManege>().addStar();
        }
    }
    public void desable(){
        gameObject.SetActive(false);
    } public void enable(){
        gameObject.SetActive(true);
    }
}
