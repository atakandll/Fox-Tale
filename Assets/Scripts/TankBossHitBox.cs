using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBossHitBox : MonoBehaviour
{
    public BossTankController bossCont;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerController.instance.transform.position.y > transform.position.y)
        {
            bossCont.TakeHit();

            PlayerController.instance.Bounce();

            gameObject.SetActive(false);
        }

    }
}
