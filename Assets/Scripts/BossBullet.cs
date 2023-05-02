using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        AudioManager.instance.PlaySFX(2);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f); // scale - olduğunda + yönde gidecek, + olduğunda - yönde gidecek.

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DealDamage();

        }
        AudioManager.instance.PlaySFX(1);


        Destroy(gameObject);

    }
}
