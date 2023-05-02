using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMine : MonoBehaviour
{
    public GameObject explosion;
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
            Destroy(gameObject); // mayına basınca yokediyor
            Instantiate(explosion, transform.position, transform.rotation);

            PlayerHealthController.instance.DealDamage();

            AudioManager.instance.PlaySFX(3);
        }

    }
    public void Explode()
    {
        Destroy(gameObject);

        AudioManager.instance.PlaySFX(3);

        Instantiate(explosion, transform.position, transform.rotation);

    }
}
