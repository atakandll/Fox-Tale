using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject theBossBattle;
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
            theBossBattle.SetActive(true);

            gameObject.SetActive(false);

            AudioManager.instance.PlayBossMusic();
        }
    }
}
