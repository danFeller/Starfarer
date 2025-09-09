using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] AudioSource[] generalSoundEffects;
    [SerializeField] AudioSource[] enemySoundEffects;
    [SerializeField] AudioSource[] bulletSoundEffects;

    public void PlayItemGetSound()
    {
        generalSoundEffects[0].Play();
    }
    public void PlayWaveCompleteSound()
    {
        generalSoundEffects[1].Play();
    }

    public void PlayEnemySoundEffect()
    {
        int rand = Random.Range(0, enemySoundEffects.Length - 1);
        enemySoundEffects[rand].Play();
    }

    public void PlayBulletSoundEffect()
    {
        int rand = Random.Range(0, bulletSoundEffects.Length - 1);
        bulletSoundEffects[rand].Play();
    }

    public void PlayDeathSoundEffect()
    {
        generalSoundEffects[2].Play();
    }

}
