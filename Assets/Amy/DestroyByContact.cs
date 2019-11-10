using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour // Code to destroy the player's "pistol shot" and whatever "enemy" it hits; Script goes on "enemy"
{
    public int scoreValue;  // If for destroying objects gives the player points
    private gameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); // Checks if this recognizes the script controlling the game
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<gameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'gameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        gameController.AddScore(scoreValue); // If for destroying objects gives the player points
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
