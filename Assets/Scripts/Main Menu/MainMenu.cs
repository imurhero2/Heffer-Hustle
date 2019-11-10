using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenuPanel;
	public GameObject creditsPanel;

	private void Start()
	{
		mainMenuPanel.SetActive(true);
		creditsPanel.SetActive(false);
	}

	public void NewGame()
    {
        SceneManager.LoadScene("Main Scene"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

	public void ToggleCredits(bool toggle)
	{
		mainMenuPanel.SetActive(!toggle);
		creditsPanel.SetActive(toggle);
	}
}
