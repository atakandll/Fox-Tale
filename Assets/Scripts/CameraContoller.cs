using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public static CameraContoller instance;
    public Transform target;
    public Transform farBackGround, middleBackGround;
    public float minHeight, maxHeight;
    public bool stopFollow;

    private void Awake()
    {
        instance = this;

    }


    // private float lastXPositon;
    private Vector2 lastPos;

    void Start()
    {
        //lastXPositon = transform.position.x;
        lastPos = transform.position;


    }


    void Update()
    {
        /* transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

         float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
         transform.position = new Vector3(transform.position.x, clampedY, transform.position.z); */


        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            // float amountToMoveX = transform.position.x - lastXPositon;
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);


            farBackGround.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackGround.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

            //lastXPositon = transform.position.x;
            lastPos = transform.position;
        }
    }
}
