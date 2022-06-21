using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{

    //the ButtonPauseMenu
    public GameObject ingameMenu;

    public void OnPAUSE()//点击“暂停”时执行此方法
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }

    public void OnRESUME()//点击“回到游戏”时执行此方法
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }

    public void OnRESTART()//点击“重新开始”时执行此方法
    {
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void OnMAIN()
    {
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnQUIT()//点击“重新开始”时执行此方法
    {
        Application.Quit();
    }
}
