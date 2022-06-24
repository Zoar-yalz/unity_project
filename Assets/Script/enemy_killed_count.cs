using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_killed_count : MonoBehaviour
{
    // Start is called before the first frame update
    public static int count=0;
    public static int total = 2;

    public GameObject winningMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countkill()
    {
        count++;
        if(count == total)
        {
            winningMenu.SetActive(true);
            //jump to victory page
        }
    }
}
