using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rd2d;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rd2d.velocity = new Vector2(speed, 0);
    }
}