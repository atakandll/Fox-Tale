using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving, ended }; // create list and allow us to only have one particular state at any particular time.
    public bossStates currentStates;
    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    public GameObject mine;
    public Transform minePoint;
    public float timeBeetweenMines;
    private float mineCounter;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    public GameObject hitBox;

    [Header("Health")]
    public int health = 5;
    public GameObject explosion, winPlatform;
    private bool isDefeated;
    public float shotSpeedUp, mineSpeedUp;

    void Start()
    {
        currentStates = bossStates.shooting; // boss başlarken ateş etmesini sağlıyoruz.

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStates)
        {
            case bossStates.shooting:

                shotCounter -= Time.deltaTime;

                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;

                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale; // repeating shooting system.

                }


                break;

            case bossStates.hurt:

                if (hurtCounter > 0) // hurt 0 dan büyük olduğu anlard çalışacak
                {
                    hurtCounter -= Time.deltaTime;

                    if (hurtCounter <= 0)
                    {
                        currentStates = bossStates.moving;

                        mineCounter = 0;

                        if (isDefeated)
                        {
                            theBoss.gameObject.SetActive(false); // boss ölme anı
                            Instantiate(explosion, theBoss.position, theBoss.rotation); // boss patlama anı

                            winPlatform.SetActive(true); // boss ölünce çıkan platformlar.
                            AudioManager.instance.StopBossMusic();

                            currentStates = bossStates.ended;


                        }
                    }

                }

                break;

            case bossStates.moving:

                if (moveRight)
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x > rightPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);  // Vector3.one,  ateş edilen kısımın da child olduğu için dönmesini istiyoruz.

                        moveRight = false;

                        EndMovement();

                    }

                }
                else
                {

                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (theBoss.position.x < leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);

                        moveRight = true;

                        EndMovement();


                    }

                }
                mineCounter -= Time.deltaTime;
                if (mineCounter <= 0)
                {
                    mineCounter = timeBeetweenMines;

                    Instantiate(mine, minePoint.position, minePoint.rotation);
                }
                break;


        }

#if UNITY_EDITOR  // any code after this line will only run inside the unity editor

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
#endif        

    }
    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");

        AudioManager.instance.PlaySFX(0); // boss hit sfx.

        BossTankMine[] mines = FindObjectsOfType<BossTankMine>(); // hareket ettikçe mayınlar birikmesin karşıdan karşıya geçerken patlasınlar kendi kendine diye böyle bir şey yaptık.

        if (mines.Length > 0)
        {
            foreach (BossTankMine foundMine in mines)
            {
                foundMine.Explode();
            }
        }
        health--;

        if (health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotSpeedUp; // hasar yedikçe ateşleme hızları ve mermi hızları artıyor.

            timeBeetweenMines /= mineSpeedUp; // hasar yedikçe ateşleme hızları ve mermi hızları artıyor.
        }
    }
    private void EndMovement()
    {
        currentStates = bossStates.shooting;

        shotCounter = 0f;

        anim.SetTrigger("StopMoving");

        hitBox.SetActive(true);

    }


}
