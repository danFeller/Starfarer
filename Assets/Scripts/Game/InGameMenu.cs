using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    float soundDuration;
    MenuSoundEffectManager menuSound;

    void Start()
    {
        menuSound = FindFirstObjectByType<MenuSoundEffectManager>();
    }

    public void LoadMainMenu()
    {
        menuSound.PlayMenuSelectSound();
        StartCoroutine(WaitToLoadMainMenu());
    }
    IEnumerator WaitToLoadMainMenu()
    {
        soundDuration = menuSound.GetMenuSelectSound().clip.length;
        yield return new WaitForSeconds(soundDuration);
        SceneManager.LoadScene("MainMenu");
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
