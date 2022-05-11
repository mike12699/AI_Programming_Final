using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
