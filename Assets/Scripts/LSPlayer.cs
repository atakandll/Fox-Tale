using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public LSManager theManager; // bileşik nesneler özelliğini kullanarak yaptık.
    public MapPoint currentPoint; // MapPoint classını aldık.
    public float moveSpeed = 10f; // hareket etme hızı.
    private bool levelLoading;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime); // artık grafik olarak player istediğimiz yöne hareket edebilcecek.

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading) // sadece istediğimiz yönlerde gitmesini sağlıyor, yakınlığa göre aşağda belirtilen harektlere göre hareket etemsini sağlayacak.
        {




            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }


            }
            else if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }


            }
            else if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }


            }
            else if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }


            }
            else if (currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked) // levelde ve boş değilse ve de kilitli değilse.
            {
                LSUIController.instance.ShowInfo(currentPoint); // MapPoint türünden olan currentPointi atayarak neyi görüntüleyeceğimizi atıyoruz.

                if (Input.GetButtonDown("Jump"))
                {


                    levelLoading = true;
                    theManager.LoadLevel(); // LSManageri çağırıp coroutinenı burdan başlatıyor.
                }
            }
        }


    }

    private void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUIController.instance.HideInfo();

        AudioManager.instance.PlaySFX(5);


    }
}
