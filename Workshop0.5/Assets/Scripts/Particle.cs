using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour
{
    private float rotationRate = 0.0f;

    void Awake()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        rotationRate = Random.Range(5.0f, 10.0f);
        Destroy(transform.gameObject, 1.0f);
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1), rotationRate);
        transform.localScale = transform.localScale * 0.95f;
    }
}
