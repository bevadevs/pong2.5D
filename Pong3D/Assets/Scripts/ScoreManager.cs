using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] SoundsManager soundsManager;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] TMP_Text scoreBoardP01;
    [SerializeField] TMP_Text scoreBoardP02;
    int scoreP01 = 0;
    int scoreP02 = 0;
    // CHANGE AFTER TESTING
    int maxScore = 1;

    private void Start()
    {
        UpdateScore(scoreBoardP01, scoreP01);
        UpdateScore(scoreBoardP02, scoreP02);
    }

    public void AddScore(string playerTag)
    {
        if (playerTag == "Player01")
        {
            scoreP02++;
            UpdateScore(scoreBoardP02, scoreP02);
            if (scoreP02 == maxScore)
            {
                soundsManager.PlaySFXAndChangeBGMusic(audioClip, menuMusic);
                gameOverScreen.GameOver("Player2");
            }
        }
        else if (playerTag == "Player02")
        {
            scoreP01++;
            UpdateScore(scoreBoardP01, scoreP01);
            if (scoreP01 == maxScore)
            {
                //soundsManager.PlaySoundEffect(audioClip);
                soundsManager.PlaySFXAndChangeBGMusic(audioClip, menuMusic);
                gameOverScreen.GameOver("Player1");
            }
        }
    }

    private void UpdateScore(TMP_Text scoreBoard, int score)
    {
        scoreBoard.text = score.ToString();
    }
}
