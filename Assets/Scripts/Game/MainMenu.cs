using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button MainMenuButton;
    [SerializeField] Button QuitButton;

    MenuSoundEffectManager menuSound;
    float soundDuration;

    void Start()
    {
        menuSound = FindFirstObjectByType<MenuSoundEffectManager>();
    }


    public void QuitGame()
    {
        menuSound.PlayMenuSelectSound();
        StartCoroutine(WaitToQuitGAme());
    }
    IEnumerator WaitToQuitGAme()
    {
        soundDuration = menuSound.GetMenuSelectSound().clip.length;
        yield return new WaitForSeconds(soundDuration);
        Debug.Log("Quitting");
        Application.Quit();
    }


    public void LoadNewGame()
    {
        menuSound.PlayMenuSelectSound();
        StartCoroutine(WaitToLoadNewGame());
    }
    IEnumerator WaitToLoadNewGame()
    {
        soundDuration = menuSound.GetMenuSelectSound().clip.length;
        yield return new WaitForSeconds(soundDuration);
        SceneManager.LoadScene("MainGame");
    }
}
