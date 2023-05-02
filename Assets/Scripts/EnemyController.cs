using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim;
    public float moveTime, waitTime;
    private float moveCount, waitCount;



    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null; // that means left point parents is not exist. // parenta göre uyarsak istediğimiz pozisyondan daha da ileri gidiyor.
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime; // our move counted to have a value so we can start counting
    }


    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y); // sağa gidiyor
                theSR.flipX = false;

                if (transform.position.x > rightPoint.position.x) // sağa gitmesi gerekenden fazlaysa 
                {
                    movingRight = false; // artık sağa gidemiyor

                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = true;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }

            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f); // choose a random time between our wait time 
            }

            anim.SetBool("isMoving", true);


        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.75f, moveTime * .75f);
            }
            anim.SetBool("isMoving", false);

        }
    }
}
