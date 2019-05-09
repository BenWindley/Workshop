using UnityEngine;
using System.Collections;

public class VirusScript : MonoBehaviour
{
    public bool gamePosition = false;
    public SpriteRenderer virusSprite;
    public SpriteRenderer docSprite;
    public GameObject dock;
    public GameObject laptopSpawn;

    private GameObject player;
    public GameObject particle;
    private bool safety = false;

    void Awake()
    {
        virusSprite.enabled = false;
        docSprite.enabled = false;
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag != "Player")
            return;

        CancelInvoke("gameplay");
        gamePosition = true;

        if (dock.GetComponent<LaptopDock>().docked)
        {
            player = col.gameObject;
            docSprite.enabled = false;
            virusSprite.enabled = true;
            if (!IsInvoking("gameplay"))
            {
                gameplay();

                safety = true;
                Invoke("turnOffSafety", 0.5f);
            }
        }
    }

    void turnOffSafety()
    {
        safety = false;
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "Player")
            return;

        CancelInvoke("gameplay");

        gamePosition = false;
        safety = false;
    }

    void gameplay()
    {
        virusSprite.enabled = !virusSprite.enabled;
        docSprite.enabled = !docSprite.enabled;

        Invoke("gameplay", 0.4f);
    }

    void Update()
    {
        if (dock.transform.childCount == 0 ||
            !dock.transform.GetChild(0).GetComponent<LaptopStatus>().virus)
        {
            CancelInvoke("gameplay");
            virusSprite.enabled = false;
            docSprite.enabled = false;
        }

        if (gamePosition)
        {
            if (virusSprite.enabled &&
                Input.GetButton(player.transform.parent.name + "Interact") &&
                dock.transform.GetChild(0).GetComponent<LaptopStatus>().dockedCorrect)
            {
                if (!safety)
                {
                    CancelInvoke("gameplay");
                    dock.transform.GetChild(0).GetComponent<LaptopStatus>().virus = false;
                    dock.transform.GetChild(0).GetComponent<LaptopStatus>().dockedCorrect = false;
                    //remove virus
                }
            }

            if (docSprite.enabled && Input.GetButton(player.transform.parent.name + "Interact"))
            {
                if (!safety)
                {
                    CancelInvoke("gameplay");
                    Destroy(dock.transform.GetChild(0).gameObject);
                    //destroy laptop
                    laptopSpawn.GetComponent<laptopSpawn>().laptopCount--;
                    //lower spawn.laptopCount

                    for (int i = 0; i < 50; i++)
                        Instantiate(particle, new Vector3(0.0f, 0.8f, 0), Quaternion.identity);
                }
            }
        }
        else
        {
            CancelInvoke("gameplay");
            virusSprite.enabled = false;
            docSprite.enabled = false;
        }

        if (virusSprite.enabled)
            transform.FindChild("Green Light").GetComponent<SpriteRenderer>().enabled = true;
        else
            transform.FindChild("Green Light").GetComponent<SpriteRenderer>().enabled = false;

        if (docSprite.enabled)
            transform.FindChild("Red Light").GetComponent<SpriteRenderer>().enabled = true;
        else
            transform.FindChild("Red Light").GetComponent<SpriteRenderer>().enabled = false;
    }
}
