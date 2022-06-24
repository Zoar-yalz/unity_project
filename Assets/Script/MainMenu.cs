using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Tips()
    {
        GameObject.Find("controller").SendMessage("show");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
