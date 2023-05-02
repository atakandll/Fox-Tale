using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    private Animator anim;
    public float bounceForce = 20;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.theRB.velocity = new Vector2(PlayerController.instance.theRB.velocity.x, bounceForce);
            anim.SetTrigger("Bounce");

        }

    }
}
