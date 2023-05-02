using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public string mainMenu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
