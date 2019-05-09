using UnityEngine;
using System.Collections;

public class EncryptionScript : MonoBehaviour
{
    public float startingX = 0.0f;
    public float startingY = 0.0f;
    private float randomAmplitude = 0.0f;

    private bool laptopAdded = false;

    private GameObject player = null;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        turnOffAllLights();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player = col.gameObject;
        }
    }

    void increaseLights()
    {
        for (int i = 1; i <= 4; i++)
        {
            if(!transform.FindChild("Light" + i).GetComponent<SpriteRenderer>().enabled)
            {
                transform.FindChild("Light" + i).GetComponent<SpriteRenderer>().enabled = true;
                return;
            }
        }

        removeEncryption();
    }

    void turnOffAllLights()
    {
        for (int i = 1; i <= 4; i++)
        {
            if (transform.FindChild("Light" + i).GetComponent<SpriteRenderer>().enabled)
            {
                transform.FindChild("Light" + i).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void startDecryption()
    {
        if (!IsInvoking("increaseLights"))
        {
            Invoke("increaseLights", 0.2f);
        }
    }

    void removeEncryption()
    {
        if (transform.parent.GetChild(0).childCount > 0)
        {
            turnOffAllLights();
            transform.parent.GetChild(0).GetChild(0).GetComponent<LaptopStatus>().encrypted = false;
            transform.parent.GetChild(0).GetChild(0).GetComponent<LaptopStatus>().dockedCorrect = false;
        }
    }
	
	void FixedUpdate()
    {
        LineRenderer line = transform.GetChild(0).GetComponent<LineRenderer>();

        float playerY = 0.0f;

        if (player == null)
        {
            playerY = 0.0f;
        }
        else
        {
            playerY = player.transform.position.y;
        }

        if (!laptopAdded &&
            transform.parent.GetChild(0).childCount > 0)
        {
            laptopAdded = true;
            randomAmplitude = Random.Range(-0.4f, 0.4f);
        }

        if(transform.parent.GetChild(0).childCount == 0)
        {
            laptopAdded = false;
        }

        for (int i = 0; i < 100; i++)
        {
            line.SetPosition(i, new Vector3(((float)i) / 150 + startingX, 0 + startingY, -1));
        }

        if (transform.parent.GetChild(0).childCount > 0)
        {
            if ((playerY - randomAmplitude > 0.1f ||
                playerY - randomAmplitude < -0.1f) &&
                transform.parent.GetChild(0).GetChild(0).transform.GetComponent<LaptopStatus>().encrypted)
            {
                CancelInvoke("increaseLights");
                turnOffAllLights();

                for (int i = 0; i < 100; i++)
                {
                    line.SetPosition(i, new Vector3(((float)i) / 150 + startingX, (playerY - randomAmplitude) * Mathf.Sin(i * 50 + Time.fixedTime * 30) / 10 + startingY, -1));
                }
            }
            else if (transform.parent.GetChild(0).GetChild(0).transform.GetComponent<LaptopStatus>().encrypted)
            {
                startDecryption();
            }
        }
    }
}
