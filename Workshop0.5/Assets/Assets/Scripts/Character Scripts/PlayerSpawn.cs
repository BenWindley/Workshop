using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour
{
    public Transform playerPrefab;

	void Start ()
    {
        string[] array = Input.GetJoystickNames();

        for (int i = 0; i < array.Length; i++)
        {
            Instantiate(playerPrefab, new Vector3(0,0,-1), Quaternion.identity);
        }
	}
}
