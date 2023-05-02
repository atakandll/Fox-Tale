using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelected, mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }

    }
    public void PauseUnPause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;

        }
        else
        {

            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;

        }

    }
    public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name); // correct level to save tat and that is

        SceneManager.LoadScene(levelSelected);
        Time.timeScale = 1f; // oyun durmadan devam etsin diye yaptık bunu



    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;

    }
}
