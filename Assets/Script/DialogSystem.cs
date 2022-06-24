using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public List<string> textList = new List<string>();

    [Header("文本框")]
    public GameObject dialogbox;

    [Header("头像")]
    public Sprite headShotA;
    public Sprite headShotB;

    [Header("SFX")]
    public AudioSource sfx;

    public int index;

    public static bool goingOn = false;
    bool playing = false;
    public static bool beforebattle = true;
    void Start()
    {
        GetTextFromFile();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && index == textList.Count)
        {
            dialogbox.SetActive(false);
            index = 0;
            goingOn = false;
            float sp = 3.0f;
            GameObject.Find("Player").SendMessage("setSpeed", sp);
            if (beforebattle)
                GameObject.Find("GameController").SendMessage("manifest");
            beforebattle = false;
        }
        else if (Input.GetKeyDown(KeyCode.K) && !playing && goingOn)
        {
            //textLabel.text = textList[index]+"\n"+textList[index+1];
            //index+=2;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile()
    {
        textList.Clear();
        index = 0;

        var lineData = textFile.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    public void ResetIdx()
    {
        index = 0;
        goingOn = true;
        StartCoroutine(SetTextUI());
        float sp = 0.0f;
        GameObject.Find("Player").SendMessage("setSpeed", sp);
    }

    public IEnumerator SetTextUI()
    {
        playing = true;
        textLabel.text = "";
        textLabel.text = textList[index] + "\n";
        if (textList[index][0] == 'A')
        {
            faceImage.sprite = headShotA;
        }
        else
            faceImage.sprite = headShotB;

        for (int i = 0; i < textList[index + 1].Length; i++)
        {
            textLabel.text += textList[index + 1][i];
            if (textList[index + 1][i] == ' ')
            {
                sfx.Play();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.03f);
            //if(i%4 ==0)
            //    sfx.Play();
        }
        sfx.Play();
        index += 2;
        playing = false;
    }
}

