using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;
    public Image fadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;
    public GameObject levelInfoPanel;
    public Text levelName, gemsFound, gemsTarget, bestTime, timeTarget;

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        FadeFromBlack();

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }

        }

    }
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;

    }
    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
    public void ShowInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName; // parametre alan metoda atadığımız MapPoint türünden değişkenin inspectorden atadığımız değeri direkt text değişkenine atadık. 

        levelInfoPanel.SetActive(true);

        gemsFound.text = "FOUND:  " + levelInfo.gemsCollected;

        gemsTarget.text = "IN LEVEL: " + levelInfo.totalGems;

        timeTarget.text = "TARGET:" + levelInfo.targetTime + "s";


        if (levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST:------";

        }
        else
        {
            bestTime.text = "BEST:" + levelInfo.bestTime.ToString("F2") + "s"; // decimal pointsi yani virgülden sonra kaç sayı geleceğini ayarlıyoruz
        }





    }
    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);

    }
}
