using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text winnerText;
    int maxScore = 10;

    public void GameOver(string winner)
    {
        gameObject.SetActive(true);
        winnerText.text = winner + " got " + maxScore + " points";
    }
}
