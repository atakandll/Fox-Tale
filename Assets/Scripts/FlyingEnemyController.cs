using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;
    public SpriteRenderer theSR;
    public float distanceToAttackPlayer, chaseSpeed;
    private Vector3 attackTarget;


    public float waitAfterAttack;
    private float attackCounter;


    void Start()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;  // tek bir yolda gidiyor child olursa.

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {


            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackPlayer) // eğer player hasar mesafesinden uzaksa normal şekilde devam
            {
                attackTarget = Vector3.zero; // pozisyonunu resetledik yyanından uzaklaştıktan sonra.

                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, points[currentPoint].position) < .05f) // pointle enemy nerdeyse aynı konuma gelince diziyi bir artıyoruz ve bir sonraki pointe geçiyoruz
                {
                    currentPoint++;

                    if (currentPoint >= points.Length) // döngünün başa gelmesi için
                    {
                        currentPoint = 0;
                    }


                }
                if (transform.position.x < points[currentPoint].position.x) // point kısmından daha az olduğunda - yönde dönücek.
                {
                    theSR.flipX = true;

                }
                else if (transform.position.x > points[currentPoint].position.x)
                {
                    theSR.flipX = false;
                }
            }
            else
            {
                //attacking the player 
                if (transform.position.x < PlayerController.instance.transform.position.x)
                {
                    theSR.flipX = true;
                }
                else if (transform.position.x > PlayerController.instance.transform.position.x)
                {
                    theSR.flipX = false;
                }

                if (attackTarget == Vector3.zero) // all variables zero resetliyor pozisyonları
                {
                    attackTarget = PlayerController.instance.transform.position;
                }
                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {

                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero; // playerın yanındayken süre geçtikten sonra poziyonlarını sıfırlıyor böylece ya saldırıcak bida ya da normal yönünden devam edicek.
                }

            }
        }


    }

}
