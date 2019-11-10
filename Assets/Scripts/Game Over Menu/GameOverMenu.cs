using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour


{
    // Start is called before the first frame update
    public TMP_Text score;
    void Start()
    {
        score.text = PlayerMovement.Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("Santiagos Scene");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title Screen Scene");
    }
}
