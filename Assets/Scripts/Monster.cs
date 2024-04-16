using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3;
    public float delay = 1;
    public Transform p1;
    public Transform p2;
    public GameObject mBullet;
    public GameObject effect;
    public GameObject enemy;

    public int hp = 10;

    public GameObject itemPow;
    public GameObject itemBomb;
    public int cnt = 0;

    Player p;

    // Start is called before the first frame update
    void Start()
    {
        //ran = new Random(0, 1);
        Invoke("CreateBullet", delay);
    }

    void CreateBullet()
    {
        Instantiate(mBullet, p1.position, Quaternion.identity);
        Instantiate(mBullet, p2.position, Quaternion.identity);

        // ¿Á±Õ»£√‚
        Invoke("CreateBullet", delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    public void Damage(int atk)
    {
        hp -= atk;

        if (hp <= 0)
        {
            GameObject go = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(enemy);
            ItemDrop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PBullet"))
        {
            StartCoroutine(ChangeColor());
            GetComponent<Monster>().Damage(p.damage);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 130 / 255f, 130 / 255f, 255 / 255f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void ItemDrop()
    {
        int ran = Random.Range(0, 10);
        if (ran == 1 || ran == 3 || ran == 5)
        {
            Instantiate(itemPow, transform.position, Quaternion.identity);
        }

        if (ran == 7)
        {
            Instantiate(itemBomb, transform.position, Quaternion.identity);
        }
    }
}
