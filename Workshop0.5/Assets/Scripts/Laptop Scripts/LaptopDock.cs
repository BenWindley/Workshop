using UnityEngine;
using System.Collections;

public class LaptopDock : MonoBehaviour
{
    public bool docked = false;
    public char type = 'a';

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Laptop")
            return;
        if (type != 'a')
        {
            bool correct = false;

            if (col.GetComponent<LaptopStatus>().virus && type == 'v')
                correct = true;

            if (col.GetComponent<LaptopStatus>().usb && type == 'u')
                correct = true;

            if (col.GetComponent<LaptopStatus>().encrypted && type == 'e')
                correct = true;

            if (!correct)
                return;
        }

        if (col.GetComponent<LaptopStatus>().interacted)
        {
            docked = false;
            col.GetComponent<LaptopStatus>().docked = false;
            col.GetComponent<LaptopStatus>().changePosition(0, 0);
        }
        else
        {
            if (!docked)
            {
                docked = true;

                col.GetComponent<LaptopStatus>().docked = true;

                if (transform.parent.name != "Identification")
                    col.GetComponent<LaptopStatus>().dockedCorrect = true;

                col.GetComponent<LaptopStatus>().changePosition(transform.position.x, transform.position.y);
                col.transform.parent = transform;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag != "Laptop")
            return;

        docked = false;
        col.GetComponent<LaptopStatus>().docked = false;
        col.GetComponent<LaptopStatus>().changePosition(0, 0);
    }
}
