using UnityEngine;
using System.Collections;

public class Identification : MonoBehaviour
{
    void Awake()
    {
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
    }

    void encrypted()
    {
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
    }

    void usb()
    {
        transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
    }

    void virus()
    {
        transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
    }

    void Update()
    {
        if (transform.GetChild(0).childCount > 0)
        {
            if (transform.GetChild(0).GetChild(0).GetComponent<LaptopStatus>().virus)
                virus();
            if (transform.GetChild(0).GetChild(0).GetComponent<LaptopStatus>().usb)
                usb();
            if (transform.GetChild(0).GetChild(0).GetComponent<LaptopStatus>().encrypted)
                encrypted();
        }
        else
        {
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
