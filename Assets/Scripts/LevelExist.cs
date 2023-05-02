using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExist : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.LevelEnd();


        }

    }
}
