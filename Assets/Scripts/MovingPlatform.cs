using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;
    public Transform platform;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(platform.position, points[currentPoint].position) < .05f) // pointle platform nerdeyse aynı konuma gelince diziyi bir artıyoruz ve bir sonraki pointe geçiyoruz
        {
            currentPoint++;

            if (currentPoint >= points.Length) // döngünün başa gelmesi için
            {
                currentPoint = 0;
            }


        }


    }
}
