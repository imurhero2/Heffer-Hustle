using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float fireRate;
    public GameObject shot;
    public Transform shotSpawn;
    // public AudioSource soundSource; // Sound source; could be put on a sound manger

    private float nextFire;
    private Rigidbody2D rd2d;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()  // Code that lets the player fire their pistol
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            // soundSource.Play();
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //This might be a jump feature, not sure if we're using tags and colliders for the ground
    {
        if (collision.collider.tag == "ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
