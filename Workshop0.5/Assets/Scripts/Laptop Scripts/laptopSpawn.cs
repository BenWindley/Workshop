using UnityEngine;
using System.Collections;

public class laptopSpawn : MonoBehaviour
{
    public int laptopCount = 0;
    private int maxLaptops = 2;
    public GameObject laptopPrefab;
    private bool spawnLaptops = false;
    public float timeTillWave = 0.0f;
	
    void spawn()
    {
        Instantiate(laptopPrefab, transform.position, Quaternion.identity);
        laptopCount++;
        Invoke("spawn", 1.0f);
    }

    void increaseMaxLaptops(int x = 1)
    {
        maxLaptops += x;
    }

    void Update()
    {
        timeTillWave -= Time.deltaTime;

        if (laptopCount <= 0)
        {
            spawnLaptops = true;
        }
        else if (timeTillWave <= 0)
        {
            spawnLaptops = true;
        }

        if (timeTillWave <= 0)
        {
            increaseMaxLaptops();
        }

        if (spawnLaptops)
        {
            timeTillWave = 20;
            spawnLaptops = false;
            Invoke("spawn", 0.2f);
        }

        if (laptopCount >= maxLaptops &&
            IsInvoking("spawn"))
        {
            CancelInvoke("spawn");
        }
	}
}
