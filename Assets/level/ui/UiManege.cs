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
    public GameObject sGame;
    public GameObject cGame;
    private IEnumerator twIn;
    private IEnumerator twOut;
    public Platform initPlatform;
    public float animationUiSpeed;

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
        }
    }


    public void startGame()
    {
        Invoke("resume", 1);
        uiBackground.resume();
    }
    public void resume()
    {
        progress.speed = 10;

        player.resume();
        background.resume();
        spawnPlatform.resume();

        twOut = tweenOut(cGame.transform, new Vector3());

        StopAllCoroutines();
        StartCoroutine(twOut);
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
        hideUi(inGame);
        Invoke("laterDaed", 2f);
    }
    private void laterDaed()
    {
        showUi(endGame);
        updateEndGame();
        endGame.GetComponent<Transform>().localScale = new Vector3(.4f, .4f, .4f);

        twIn = tweenIn(endGame.GetComponent<Transform>().transform, new Vector3(1, 1, 1));

        StopAllCoroutines();
        StartCoroutine(twIn);
    }
    public void addStar()
    {
        star++;
        GameObject.FindWithTag("starInGame").GetComponent<TextMeshProUGUI>().text = star.ToString();
    }
    public IEnumerator tweenIn(Transform from, Vector3 to)
    {
        bool endTween = true;
        while (endTween)
        {
            from.localScale = Vector3.Lerp(from.localScale, to, animationUiSpeed * Time.deltaTime);
            if (Vector3.Distance(from.localScale, to) < 0.05f)
            {
                endTween = false;
            }
            yield return null;
        }

        StopCoroutine(twIn);
        yield return null;
    }
    public IEnumerator tweenOut(Transform from, Vector3 to)
    {
        bool endTween = true;
        while (endTween)
        {
            from.localScale = Vector3.Lerp(from.localScale, to, animationUiSpeed * Time.deltaTime);
            if (Vector3.Distance(from.localScale, to) < 0.05f)
            {
                endTween = false;
            }
            yield return null;
        }
        StopCoroutine(twOut);
        yield return null;
    }
    public void resetPoints()
    {
        star = 0;
        money = 0;

        updateInGame();
    }
    private void updateInGame()
    {
        if (GameObject.FindWithTag("starInGame").activeInHierarchy)
            GameObject.FindWithTag("starInGame").GetComponent<TextMeshProUGUI>().text = star.ToString();
    }
    private void updateEndGame()
    {
        if (GameObject.FindWithTag("starEndGame").activeInHierarchy)
        {
            GameObject.FindWithTag("starEndGame").GetComponent<TextMeshProUGUI>().text = star.ToString();
            GameObject.FindWithTag("moneyEndGame").GetComponent<TextMeshProUGUI>().text = Time.time.ToString("0.00");
        }
    }
    public void restart()
    {
        player.restart();
        uiBackground.restart();
        spawnPlatform.restart();
        initPlatform.restart();

        resume();

        showUi(inGame);

        resetPoints();
    }

    private void laterRestart()
    {
        background.restart();
    }
    public void showUi(GameObject ui)
    {
        if (!ui.activeInHierarchy)
            ui.SetActive(true);
    }
    public void hideUi(GameObject ui)
    {
        if (ui.activeInHierarchy)
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
