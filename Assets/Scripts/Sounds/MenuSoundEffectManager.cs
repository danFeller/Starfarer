using UnityEngine;

public class MenuSoundEffectManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioClips;

    public void PlayMenuSelectSound()
    {
        audioClips[0].Play();
    }

    public AudioSource GetMenuSelectSound()
    {
        return audioClips[0];
    }
}
