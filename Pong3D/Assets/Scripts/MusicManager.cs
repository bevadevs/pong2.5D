using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //[SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    float initialVolume;

    private void Start()
    {
        initialVolume = audioSource.volume;
    }

    // Para indicar desde otro script qué música queremos que suene
    public void PlayMusic(AudioClip musicClip)
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void LowerVolume()
    {
        audioSource.volume = initialVolume * 0.2f;
    }

    public IEnumerator volumeBackToNormal(float soundEffectDuration)
    {
        yield return new WaitForSeconds(soundEffectDuration);
        audioSource.volume = initialVolume;
    }

    // Para parar la música desde otro script
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
