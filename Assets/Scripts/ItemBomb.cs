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

    Player p;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.AddForce(new Vector3(itemVelocity, itemVelocity, 0f));
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        if (p.pow < 3)
    //            damage += p.gameObject.GetComponent<Player>().GetDamage();

    //        Destroy(gameObject);
    //    }
    //}
}
