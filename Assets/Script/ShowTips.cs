using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTips : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tips;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show()
    {
        tips.SetActive(true);
    }
    public void hide()
    {
        tips.SetActive(false);
    }
}
