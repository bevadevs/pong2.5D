using UnityEngine;
using TMPro;


public class GameOverScreen : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    public TMP_Text winnerText;
    int maxScore = 3;

    public void GameOver(string winner)
    {
        musicManager.StopMusic();
        gameObject.SetActive(true);
        winnerText.text = winner + " got " + maxScore + " points";
        foreach (GameObject ball in IAPlayer02.balls)
        {
            // Volvemos estática la pelota para que no pueda sacarse más
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
