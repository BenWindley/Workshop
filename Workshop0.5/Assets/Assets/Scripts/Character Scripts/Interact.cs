using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
    private bool interacted = false;
    private bool interactDown = false;

    bool checkForLaptops()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        foreach (Collider2D c in colliders)
        {
            if (c.tag == "Laptop")
            {
                if (!c.GetComponent<LaptopStatus>().interacted &&
                    !c.GetComponent<LaptopStatus>().dockedCorrect)
                {
                    c.transform.parent = transform;
                    c.transform.localPosition = new Vector2(0, -0.1f);
                    c.transform.localRotation = Quaternion.identity;
                    c.transform.GetComponent<LaptopStatus>().interacted = true;
                    return true;
                }
            }
        }

        return false;
    }

    void Update()
    {
        if (Input.GetButton(transform.parent.name + "Interact"))
        {
            if (!interactDown)
            {
                interactDown = true;

                if (interacted)
                {
                    transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(4 * Input.GetAxis(transform.parent.name + "Horizontal"),
                        -4 * Input.GetAxis(transform.parent.name + "Vertical")) ,
                        ForceMode2D.Impulse);

                    transform.GetChild(0).GetComponent<LaptopStatus>().interacted = false;
                    transform.DetachChildren();

                    interacted = false;
                }
                else
                {
                    interacted = checkForLaptops();
                }
            }
        }
        else
        {
            interactDown = false;
        }
    }
}
