using UnityEngine;
using System.Collections;

public class USBScript : MonoBehaviour
{
    public bool gamePosition = false;
    private bool pressed = false;
    public GameObject dock;
    public SpriteRenderer upSprite;
    public SpriteRenderer downSprite;

    private GameObject player;
    public GameObject particle;

    private int counter = 0;

    void Awake()
    {
        upSprite.enabled = true;
        downSprite.enabled = false;
    }
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Player")
            return;

        if (dock.GetComponent<LaptopDock>().docked)
        {
            player = col.gameObject;
            gamePosition = true;
            upSprite.enabled = true;
            downSprite.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        gamePosition = false;
    }


    void Update()
    {
        if (gamePosition)
        {
            if (dock.transform.childCount > 0)
            {
                if (Input.GetButton(player.transform.parent.name + "Interact") &&
                    dock.transform.GetChild(0).GetComponent<LaptopStatus>().dockedCorrect)
                {
                    if (!pressed)
                    {
                        pressed = true;
                        counter++;
                        downSprite.enabled = !downSprite.enabled;
                        upSprite.enabled = !upSprite.enabled;
                        if(downSprite.enabled)
                        {
                            for(int i = 0; i < 20; i++)
                            Instantiate(particle, new Vector3(1.2f,-0.8f,0), Quaternion.identity);
                        }

                            if (counter > 10 &&
                            dock.transform.childCount > 0)
                        {
                            counter = 0;
                            dock.transform.GetChild(0).GetComponent<LaptopStatus>().usb = false;
                            dock.transform.GetChild(0).GetComponent<LaptopStatus>().dockedCorrect = false;
                            downSprite.enabled = false;
                            upSprite.enabled = true;
                        }
                    }
                }
                else
                    pressed = false;
            }
        }

        if (gamePosition &&
            dock.transform.childCount > 0)
        {
            if (dock.transform.GetChild(0).GetComponent<LaptopStatus>().dockedCorrect)
                transform.Find("Blue Light").GetComponent<SpriteRenderer>().enabled = true;
            else
                transform.Find("Blue Light").GetComponent<SpriteRenderer>().enabled = false;
        }
        else
            transform.Find("Blue Light").GetComponent<SpriteRenderer>().enabled = false;
    }
}
