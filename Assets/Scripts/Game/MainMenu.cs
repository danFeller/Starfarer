using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button QuitButton;

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Debug.Log("QUitting");
        Application.Quit();
    }

}
