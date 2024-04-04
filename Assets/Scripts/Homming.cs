using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homming : MonoBehaviour
{
    GameObject target;
    public float speed = 3f;

    Vector2 dir;
    Vector2 dirNo;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");

        // A - B -> A를 바라보는 벡터
        dir = target.transform.position - transform.position;
        // 방향벡터만 구하기 - 단위벡터 1의크기로 만듦
        dirNo = dir.normalized;

        // Vector3.MoveTowards 유니티로 구현된 함수

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
