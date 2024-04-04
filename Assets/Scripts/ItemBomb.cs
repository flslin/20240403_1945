using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomb : MonoBehaviour
{
    public GameObject bomb;
    //public float moveX = 1;
    //public float moveY;
    //public float speed;

    public float itemVelocity = 20f;
    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.AddForce(new Vector3(itemVelocity, itemVelocity, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        //if (moveX < 2.4)
        //    moveX += Time.deltaTime;
        //else if (moveX > 2.4)
        //    moveX -= Time.deltaTime;
        //if (moveY < 4.4)
        //    moveY += Time.deltaTime;
        //else if (moveY > 4.4)
        //    moveY -= Time.deltaTime;

        //if (moveX > -2.4)
        //    moveX += Time.deltaTime;
        //else if (moveX < -2.4)
        //    moveX -= Time.deltaTime;
        //if (moveY > -4.4)
        //    moveY += Time.deltaTime;
        //else if (moveY < -4.4)
        //    moveY -= Time.deltaTime ;

        //bomb.transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 1);
    }

}
