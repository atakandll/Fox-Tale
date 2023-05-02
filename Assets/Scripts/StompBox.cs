using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible; // health pickup ekledik inspectorden
    [Range(0, 100)] public float chanceToDrop; // enemyi öldürünce ortaya toplanabilir bir şey çıkacak ve bunu şansa bağlı yapıyoruz.
                                               // rangeni belirledik çünkü inspectorden random aralığından fazla girebilirlerdi
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false); // when touch the enemy it is remove the game, parent dedik cunku ona ait parent var ve direkt kendisini kaldırdğımızda parentin tranformu harekete devam ediyor

            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f); // random bir sayı atadık şansımıza göre gelicek healty pickup

            if (dropSelect <= chanceToDrop) // eğer  random sayı inspectorden atayacağımzdan küçükse olucak.
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation); // burda ortaya çıkıcak healty pickup

            }
            AudioManager.instance.PlaySFX(3);


        }

    }
}
