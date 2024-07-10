using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

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
        int ballListSize = 0;
        foreach (GameObject ball in IAPlayer02.balls)
        {
            ballListSize++;
            //ball.gameObject.SetActive(false);
            Destroy(ball);
        }
        Debug.Log("From GameOverScreen: " + ballListSize);
    }
}
