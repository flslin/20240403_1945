using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ItemBomb : MonoBehaviour
{
    public GameObject bomb;
    //public float moveX = 1;
    //public float moveY;
    //public float speed;

    public float itemVelocity = 20f;
    Rigidbody2D rbody;

    public int pow = 0;
    Player p;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.AddForce(new Vector3(itemVelocity, itemVelocity, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pow++;
            switch (pow)
            {
                case 0:
                    p.damage = 3;
                    break;
                case 1:
                    p.damage = 5;
                    break;
                case 2:
                    p.damage = 7;
                    break;
                case 3:
                    p.damage = 10;
                    break;
            }
        }

        if (pow >= 3)
            pow = 3;
    }
}
