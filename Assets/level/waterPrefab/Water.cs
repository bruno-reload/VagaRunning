using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject endGame;
    private float time;
    private Player player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject.GetComponent<Player>();
            other.GetComponent<Player>().playerDead();
            time = Time.time;
        }
    }
    private void Update()
    {
        if(player)
        if (player.readyToDie && Time.time - time > 1)
        {
            GameObject.FindWithTag("interface").GetComponent<UiManege>().showUi(endGame);
        }
    }
}
