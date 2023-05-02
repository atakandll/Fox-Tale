using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

    public GameObject objectToSwitch;
    private SpriteRenderer theSR;
    public Sprite downSprite;
    public bool hasSwitched;
    public bool deactiveOnSwitch;
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasSwitched)
        {
            if (deactiveOnSwitch)
            {
                objectToSwitch.SetActive(false);

            }
            else
            {
                objectToSwitch.SetActive(true);

            }
            objectToSwitch.SetActive(false);
            theSR.sprite = downSprite;
            hasSwitched = true;
        }
    }
}
