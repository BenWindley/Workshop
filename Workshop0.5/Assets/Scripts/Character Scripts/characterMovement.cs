using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour
{
    public float speed = 1.0f;

    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        int a = players.Length;

        transform.gameObject.name = "P" + a/2 + "_";
    }

    void Movement()
    {
        float x = Input.GetAxis(name + "Horizontal");
        float y = -Input.GetAxis(name + "Vertical");

        transform.Translate(Vector2.right * x * 0.03f);
        transform.Translate(Vector2.up * y * 0.03f);
    }

    void FixedUpdate()
    {
        Movement();
    }
}
