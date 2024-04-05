using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float flag = 1;
    float speed = 2;
    public float hp = 300;
    public GameObject effect;

    public GameObject bullet;
    public GameObject bullet2;
    public Transform pos1;
    public Transform pos2;

    public Rigidbody2D rbody;
    public float itemVelocity = 120f;
    BossHead head;

    // Start is called before the first frame update
    void Start()
    {
        head = GetComponent<BossHead>();
        GetComponent<BoxCollider2D>().enabled = false;
        //rbody = GetComponent<Rigidbody2D>();
        //rbody.AddForce(new Vector3(itemVelocity, 0f, 0f));
        StartCoroutine(BossBullet());
        StartCoroutine(CircleFire());
    }

    IEnumerator BossBullet()
    {
        while (true)
        {
            Instantiate(bullet, pos1.position, Quaternion.identity);
            Instantiate(bullet, pos2.position, Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
        }
    }


    IEnumerator CircleFire()
    {
        // ���� �ֱ�
        float attackRate = 3;
        // �߻� ����
        int count = 30;
        // �߻�ü ������ ����
        float intervalAngle = 360 / count;
        // ���ߵǴ� ����
        float weightAngle = 0f;

        // �� ���·� �߻�(count��ŭ)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                // �߻�ü ����
                GameObject clone = Instantiate(bullet2, transform.position, Quaternion.identity);
                // �߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                // �߻�ü �̵� ����(����)
                // Cos(����) ���� ������ ���� ǥ���� ���� pi/180 ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                // Sin(rkreh) ���� ������ ���� ǥ���� ���� pi/180 ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                // �߻�ü �̵� ���� ����
                //clone = GetComponent<BossBullet>().Move(new Vector2(x, y));
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }
            // �߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;
            yield return new WaitForSeconds(attackRate);
            // 3�ʸ��� �߻�
        }
    }

    public void Damage(int atk)
    {
        hp -= atk;

        if (hp <= 0)
        {
            GameObject go = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 1)
            flag *= -1;
        if (transform.position.x < -1)
            flag *= -1;

        //transform.Translate(new Vector2((flag * speed * Time.deltaTime), 0));


    }

    public void Head()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PBullet"))
            StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 130 / 255f, 130 / 255f, 255 / 255f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
