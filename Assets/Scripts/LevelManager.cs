using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;
    public string levelToLoad; // atayacağımız leveli burdan seçiyoruz
    public float timeInLevel;
    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        timeInLevel = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;

    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());

    }
    private IEnumerator RespawnCo()
    {


        PlayerController.instance.gameObject.SetActive(false);


        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed)); // karanlık olması için gereken süreyi bölerek bu şekilde geri döndürülmesini sağladık

        UIController.instance.FadeToBlack(); // metod çağrıldı

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);

        UIController.instance.FadeFromBlack();




        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint; //checkpointle aynı konuma geliyoruz

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth; //doğduktan sonra canımızı full göstermek için

        UIController.instance.UpdateHealthDisplay();

    }
    public void LevelEnd()
    {
        StartCoroutine(EndLevelCo());

    }
    public IEnumerator EndLevelCo()
    {
        AudioManager.instance.PlayLevelVictory();

        PlayerController.instance.stopInput = true;

        CameraContoller.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 3f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1); //yeni veriyi kaydettiğimiz kısım. 1 ise true 0 ise false.

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);


        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {


            if (gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))  // bu kısım sadece en yüksek skoru aldığımız gemleri saveleyen kısım 
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected); // en yüksek gemsleri topladığımız kısım.

            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_time", gemsCollected); // eğer yüksek değilse normal topladığımnızı yazıcaz

        }


        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time")) // zaman için en düşük zamanı tuttuğumuz kısım
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel); // burada tutuyoruz


            }

        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel); // eğer fazla zaman olduysa direkt bu kısmı alıyor


        }




        SceneManager.LoadScene(levelToLoad);

    }
}
