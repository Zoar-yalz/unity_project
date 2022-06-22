using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class castBehaviour : MonoBehaviour
{
    public int damage=100;
    private static Vector2 defaultDirection = new Vector2(0, 1);
    public float speed=1.0F;
    public Rigidbody2D rb;
    public string friendlyTag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D GetObj)
    {
        if (GetObj.tag != friendlyTag)
        {
            if(GetObj.gameObject.GetComponent<life>() != null)
                GetObj.gameObject.GetComponent<life>().receiveDamage(damage);
            Destroy(gameObject);
        }
    }
    public void init(Vector2 direction,Vector3 position)
    {
        rb.velocity = speed * (direction.normalized);
        transform.position = position;
        float angle =  Vector2.Angle(defaultDirection, direction);
        if (direction.x > 0)
        {
            angle *= -1;
        }
        gameObject.transform.Rotate(0,0,angle,Space.Self);
        Destroy(gameObject, 5f);
    }
}
