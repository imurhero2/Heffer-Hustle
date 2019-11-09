using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour // Code to destroy "Money Bags" and tell the Game Controller script to increase the player's score
{
    public int scoreValue;
    private gameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
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
    void OnTriggerEnter(Collider player)
    {
        gameController.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
