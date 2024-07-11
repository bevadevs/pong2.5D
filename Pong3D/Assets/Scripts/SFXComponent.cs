using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SFXComponent : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] MusicManager musicManager;

    private void Awake()
    {
        musicManager = FindObjectOfType<MusicManager>();
    }

    // Este m�todo se ejecuta cuando una pala choca con la pelota
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            audioSource.Play();
        }
    }

    // Este m�todo se ejecuta cuando la pelota entra en una porter�a y cuando recoge alg�n power up
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

    // Este m�todo reproduce el sonido de victoria y cambia de la m�sica de fondo del juego a la del men�
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
