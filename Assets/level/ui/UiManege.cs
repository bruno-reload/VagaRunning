using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManege : MonoBehaviour
{
    private FlowControll player;
    private FlowControll background;
    private FlowControll uiBackground;

    private FlowControll spawnPlatform;
    private Progress progress;
    private GameObject endGame = null;
    private GameObject inGame = null;
    private GameObject sGame = null;
    private GameObject cGame = null;

    private int star = 0;
    private float money = 0;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        background = GameObject.FindWithTag("Background").GetComponent<Background>();
        uiBackground = GameObject.FindWithTag("transition").GetComponent<UiBackground>();
        spawnPlatform = GameObject.FindWithTag("spawnPlatform").GetComponent<SpawnPlatform>();

        progress = GameObject.FindWithTag("speedControll").GetComponent<Progress>();
        pauseGame();

        foreach (RectTransform item in GetComponentInChildren<RectTransform>())
        {
            if (item.gameObject.tag == "endGame")
            {
                endGame = item.gameObject;
            }
            if (item.gameObject.tag == "inGame")
            {
                inGame = item.gameObject;
            }
            if (item.gameObject.tag == "sGame")
            {
                sGame = item.gameObject;
            }
            if (item.gameObject.tag == "cGame")
            {
                cGame = item.gameObject;
            }
        }
    }


    public void startGame()
    {
        Invoke("playGame", 1);
        uiBackground.resume();
    }
    public void playGame()
    {
        progress.speed = 10;

        player.resume();
        background.resume();
        spawnPlatform.resume();
    }
    public void dead()
    {
        (player as Player).playerDead();
        (background as Background).dead();

        if (!endGame || !inGame)
        {
            Debug.Log("ui game in and ui game end tags  were not define");
            return;
        }

        Invoke("deadUI", 2.5f);
    }
    private void deadUI()
    {
        showUi(endGame);
        hideUi(inGame);
        getStar();
    }
    public void addStar()
    {
        star++;
        GameObject.FindWithTag("starInGame").GetComponent<TextMeshProUGUI>().text = star.ToString();
    }
    public int getStar()
    {
        GameObject.FindWithTag("starEndGame").GetComponent<TextMeshProUGUI>().text = star.ToString(); 
        GameObject.FindWithTag("moneyEndGame").GetComponent<TextMeshProUGUI>().text = Time.time.ToString("0.00");
        return star;
    }
    public void restart()
    {
        player.restart();
        background.restart();
        uiBackground.restart();

        playGame();

        showUi(inGame);

        hideUi(endGame);
        hideUi(sGame);
        hideUi(cGame);
        star = 0;
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
        // background.pause();
        spawnPlatform.pause();
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
