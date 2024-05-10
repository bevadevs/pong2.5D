using UnityEngine;
using System.Collections;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] MusicManager musicManager;

    private void Awake()
    {
        musicManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MusicManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter()
    {
        PlaySoundEffect(audioClip);
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        musicManager.LowerVolume();
        audioSource.PlayOneShot(clip);
        float clipLength = clip.length;
        StartCoroutine(musicManager.volumeBackToNormal(clipLength));
    }

    // Revisar, no hace lo que quiero
    public void PlaySFXAndChangeBGMusic(AudioClip SFXClip, AudioClip newBGClip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(SFXClip);
        float clipLength = SFXClip.length;
        audioSource.clip = newBGClip;
        StartCoroutine(PlayAfterDelay(clipLength));
    }

    IEnumerator PlayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
