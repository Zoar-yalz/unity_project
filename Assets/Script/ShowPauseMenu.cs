using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPauseMenu : MonoBehaviour
{
    bool isStop = true;
    public GameObject Menu;

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnResume()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }

    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }    // Start is called before the first frame update
    public void OnMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                Menu.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                Menu.SetActive(false);
            }
        }
    }
}
