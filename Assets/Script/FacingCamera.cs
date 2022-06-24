using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    List<Transform> childs;
    void Start()
    {
        childs = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i));
        }
    }
    void AddComponent(Transform transform)
    {
        childs.Add(transform);
    }
    void Update()
    {
        for (int i = childs.Count - 1; i >= 0; i--)
        {
            if (childs[i] == null)
                childs.RemoveAt(i); // O(n)
            else
            {
                childs[i].rotation = Camera.main.transform.rotation;
            }
        }
    }
}
