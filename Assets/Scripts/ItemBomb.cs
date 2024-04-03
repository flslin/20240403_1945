using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomb : MonoBehaviour
{
    public GameObject bomb;
    public float moveX = 1;
    public float moveY;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveX < 2.4)
            moveX += Time.deltaTime * speed;
        else if (moveX > -2.4)
            moveX -= Time.deltaTime * speed;

        if (moveY < 4.4)
            moveY += Time.deltaTime * speed;
        else if (moveY > -4.4)
            moveY -= Time.deltaTime * speed;

        bomb.transform.Translate(moveX * speed * Time.deltaTime, moveY * speed * Time.deltaTime, 1);
    }

}
