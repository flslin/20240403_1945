using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PBullet : MonoBehaviour
{
    public float Speed = 7.0f;

    //ItemBomb item = new ItemBomb();
    ItemBomb item;
    int dam;


    private void Start()
    {
        dam = GetComponent<Player>().damage;
        item = GetComponent<ItemBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damage(dam);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().Damage(dam);
            Destroy(gameObject);
        }

        //if (collision.CompareTag("Item"))
        //{
        //    switch (player.pow)
        //    {
        //        case 0:
        //            atk = 3;
        //            break;
        //        case 1:
        //            atk = 5;
        //            break;
        //        case 2:
        //            atk = 7;
        //            break;
        //        case 3:
        //            atk = 10;
        //            break;
        //    }
        //}
    }
}
