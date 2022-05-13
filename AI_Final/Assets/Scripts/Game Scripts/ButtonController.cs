using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject helpPanel;

    public void ResetGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
        titlePanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        titlePanel.SetActive(true);
        helpPanel.SetActive(false);
    }
}
