using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManege : MonoBehaviour
{
    private FlowControll player;
    private FlowControll background;
    private FlowControll uiBackground;

    private FlowControll spawnPlatform;
    private Progress progress;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        background = GameObject.FindWithTag("Background").GetComponent<Background>();
        uiBackground = GameObject.FindWithTag("transition").GetComponent<UiBackground>();
        spawnPlatform = GameObject.FindWithTag("spawnPlatform").GetComponent<SpawnPlatform>();

        progress = GameObject.FindWithTag("speedControll").GetComponent<Progress>();
        pauseGame();
    }

   
    public void startGame()
    {
        Invoke("playGame",1);
        uiBackground.resume();
    }
    public void playGame()
    {
        progress.speed = 10;

        player.resume();
        background.resume();
        spawnPlatform.resume();
    }
    public void restart()
    {

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
        progress.speed = 0;

        player.pause();
        background.pause();
        spawnPlatform.pause();
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
