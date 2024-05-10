using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    
    public void LoadPvE()
    {
        SceneManager.LoadScene("PvEMode");
    }

    public void LoadPvP()
    {
        SceneManager.LoadScene("PvPMode");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
