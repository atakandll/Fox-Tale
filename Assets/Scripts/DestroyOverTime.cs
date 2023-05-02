using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime); // destroy için süresini belirledik


    }
}
