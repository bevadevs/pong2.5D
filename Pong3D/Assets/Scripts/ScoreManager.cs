using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] SFXComponent sfxComponent;
    [SerializeField] AudioClip victoryClip;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] TMP_Text scoreBoardP01;
    [SerializeField] TMP_Text scoreBoardP02;
    int scoreP01 = 0;
    int scoreP02 = 0;
    int maxScore = 3;

    private void Start()
    {
        UpdateScore(scoreBoardP01, scoreP01);
        UpdateScore(scoreBoardP02, scoreP02);
    }

    public void AddScore(string areaTag)
    {
        if (areaTag == "GoalArea01")
        {
            scoreP02++;
            UpdateScore(scoreBoardP02, scoreP02);
            if (scoreP02 == maxScore)
            {
                sfxComponent.PlaySFXAndChangeBGMusic(victoryClip, menuMusic);
                gameOverScreen.GameOver("Red Player");
            }
        }
        else if (areaTag == "GoalArea02")
        {
            scoreP01++;
            UpdateScore(scoreBoardP01, scoreP01);
            if (scoreP01 == maxScore)
            {
                sfxComponent.PlaySFXAndChangeBGMusic(victoryClip, menuMusic);
                gameOverScreen.GameOver("Blue Player");
            }
        }
    }

    private void UpdateScore(TMP_Text scoreBoard, int score)
    {
        scoreBoard.text = score.ToString();
    }
}
