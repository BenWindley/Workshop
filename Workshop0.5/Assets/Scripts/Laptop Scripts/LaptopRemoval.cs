using UnityEngine;
using System.Collections;

public class LaptopRemoval : MonoBehaviour
{
    public GameObject laptopSpawn;
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag != "Laptop")
            return;

        if (!col.GetComponent<LaptopStatus>().virus &&
            !col.GetComponent<LaptopStatus>().usb &&
            !col.GetComponent<LaptopStatus>().encrypted)
        {
            if (col.transform.parent == null)
            {
                Destroy(col.transform.gameObject);
                //destroy laptop
                laptopSpawn.GetComponent<laptopSpawn>().laptopCount--;
            }
        }
    }
}
