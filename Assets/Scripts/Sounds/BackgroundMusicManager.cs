using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] AudioSource[] backgroundMusic;

    public void PlayBackgroundMusic()
    {
        backgroundMusic[0].Play();
    }
}
