using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;
    int attack = 20;

    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
    }

    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(attack++);
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }

        if (collision.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().Damage(attack);
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 0.5f);
        }
    }
    // 계속 충돌이 일어날 때
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(attack++);
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }

        if (collision.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().Damage(attack);
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);

            Destroy(go, 1);
        }
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 130 / 255f, 130 / 255f, 255 / 255f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
