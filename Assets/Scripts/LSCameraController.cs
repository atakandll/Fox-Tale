using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraController : MonoBehaviour
{
    public Vector2 minPos, maxPos; // max ve min idebileceği yerler için aldık
    public Transform target; // playeri atıyoruz.
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate() // late updatede camera playerın hareketinden sonra çalışır.
    {
        float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x); // max ve min değerleri ile kameranın max ve min gidebileceği yerleri belirledik
        float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

        transform.position = new Vector3(xPos, yPos, transform.position.z);

    }
}
