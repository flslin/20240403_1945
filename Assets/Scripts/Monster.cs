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
    public PBullet pb;

    public int ran;

    // Start is called before the first frame update
    void Start()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PBullet"))
        {
            StartCoroutine(ChangeColor());
            Destroy(collision.gameObject);
            hp -= pb.damage;

            if (hp <= 0)
            {
                GameObject go = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                Destroy(go, 0.5f);
                Destroy(enemy);
                ran = Random.Range(0, 1);
            }
        }
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 130 / 255f, 130 / 255f, 255 / 255f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void item()
    {
        if (ran == 1)
        {

        }
    }
}
