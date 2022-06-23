using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    //public GameObject Button;
    public GameObject talkUI;

    public bool isActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isActive = false;
        DialogSystem.goingOn = false;
    }

    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.J) && !DialogSystem.goingOn)
        {
            GameObject.Find("GameController").SendMessage("ResetIdx");
            talkUI.SetActive(true);
        }
    }

}

