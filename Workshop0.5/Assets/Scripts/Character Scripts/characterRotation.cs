using UnityEngine;
using System.Collections;

public class characterRotation : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis(transform.parent.name + "Horizontal");
        float y = - Input.GetAxis(transform.parent.name + "Vertical");

        if(x != 0 || y != 0)
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90);
    }
}
