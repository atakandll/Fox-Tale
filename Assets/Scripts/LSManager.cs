using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public LSPlayer thePlayer; // bileşik nesneler

    private MapPoint[] allPoints;

    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        StartCoroutine(loadToLevelCo());

    }

    public IEnumerator loadToLevelCo()
    {

        AudioManager.instance.PlaySFX(4); // level selected music

        LSUIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / LSUIController.instance.fadeSpeed) + .25f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad); // levele hemen geçmek istemiyoruz 1 saniye gibi bir süreyle geçmek  istiyoruz ve bunun için coroutine kullandık.

    }
}
