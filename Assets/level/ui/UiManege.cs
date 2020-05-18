using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManege : MonoBehaviour
{
    private Player player;
    private Background background;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        background = GameObject.FindWithTag("Background").GetComponent<Background>();
    }
    public void playGame()
    {
        GameObject.FindWithTag("speedControll").GetComponent<Progress>().speed = 10;
        player.playerRun();
        player.resume();
        // background.resume();
    }
    public void restart(){

    }
    public void showUi(GameObject ui)
    {
        ui.SetActive(true);
    }
    public void hideUi(GameObject ui)
    {
        ui.SetActive(false);
    }
    public void pauseGame()
    {
        GameObject.FindWithTag("speedControll").GetComponent<Progress>().speed = 0;
        player.pause();
        background.pause();
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
