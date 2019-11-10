using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour


{
    // Start is called before the first frame update
    public Text score;
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
        SceneManager.LoadScene("Main Scene");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title Screen Scene");
    }
}
