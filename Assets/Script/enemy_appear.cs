using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_appear : MonoBehaviour
{
    // Start is called before the first frame update
     public List<GameObject> enemyList;

    void Start()
    {
        
    }

    void addEnemy(GameObject e)
    {
        enemyList.Add(e);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
     
    void manifest()
    {
        for(int i=0;i < enemyList.Count; i++)
        {
            enemyList[i].SetActive(true);
        }
    }
}
