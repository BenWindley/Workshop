using UnityEngine;
using System.Collections;

public class LaptopStatus : MonoBehaviour
{
    public bool interacted = false;
    public bool dockedCorrect = false;
    public bool docked = false;
    public bool virus = false;
    public bool usb = false;
    public bool encrypted = false;

    private float targetX = 0.0f;
    private float targetY = 0.0f;

    public Sprite laptop1;
    public Sprite laptop2;
    public Sprite laptop3;
    public Sprite laptop4;
    public Sprite laptop5;
    public Sprite laptop6;
    public Sprite laptop7;
    public Sprite laptop8;
    public Sprite laptop9;
    public Sprite laptop10;

    void Awake()
    {
        int problem = Random.Range(0, 3);

        switch (problem)
        {
            case 0:
                virus = true;
                break;
            case 1:
                usb = true;
                break;
            case 2:
                encrypted = true;
                break;
        }

        if (Random.Range(0.0f, 1.0f) > 0.8f)
        {
            problem = Random.Range(0, 3);

            switch (problem)
            {
                case 0:
                    virus = true;
                    break;
                case 1:
                    usb = true;
                    break;
                case 2:
                    encrypted = true;
                    break;
            }

            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                problem = Random.Range(0, 3);

                switch (problem)
                {
                    case 0:
                        virus = true;
                        break;
                    case 1:
                        usb = true;
                        break;
                    case 2:
                        encrypted = true;
                        break;
                }
            }
        }

        Sprite laptop = laptop1;

        switch(Random.Range(1,10))
        {
            case 1:
                laptop = laptop1;
                break;
            case 2:
                laptop = laptop2;
                break;
            case 3:
                laptop = laptop3;
                break;
            case 4:
                laptop = laptop4;
                break;
            case 5:
                laptop = laptop5;
                break;
            case 6:
                laptop = laptop6;
                break;
            case 7:
                laptop = laptop7;
                break;
            case 8:
                laptop = laptop8;
                break;
            case 9:
                laptop = laptop9;
                break;
            case 10:
                laptop = laptop10;
                break;
        }

        transform.GetComponent<SpriteRenderer>().sprite = laptop;


        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(-1.0f, -3.0f)), ForceMode2D.Impulse);
    }

    public void changePosition(float x, float y)
    {
        targetX = x;
        targetY = y;
    }

    void FixedUpdate()
    {
        if (docked)
        {
            transform.position = Vector2.LerpUnclamped(new Vector2(transform.position.x, transform.position.y), new Vector2(targetX, targetY), 0.3f);
        }
        if (interacted)
        {
            transform.localPosition = new Vector2(0, -0.175f);
        }
    }
}
