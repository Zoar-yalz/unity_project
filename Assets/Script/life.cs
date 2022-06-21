using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public int life_num;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void receiveDamage(int damage)
    {
        life_num -= damage;
        Debug.Log("damage:"+damage);
        if (life_num<=0)
        {
            Debug.Log("dead!");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
