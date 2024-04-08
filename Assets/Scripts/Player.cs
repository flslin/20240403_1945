using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;

    public Transform pos = null;
    //public GameObject bullet;
    public int hp = 5;
    public int damage = 5;

    public bool ch = true;

    public int pow = 0;
    // 미사일 갯수 여러개
    public List<GameObject> bullet = new List<GameObject>();

    public GameObject lazer;
    public float gValue = 0;
    public Image gage;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // GetAxis l-1 c0 r1
        if (Input.GetAxis("Horizontal") <= -0.1f)
            ani.SetBool("left", true);
        else
            ani.SetBool("left", false);

        if (Input.GetAxis("Horizontal") >= 0.1f)
            ani.SetBool("right", true);
        else
            ani.SetBool("right", false);

        if (Input.GetAxis("Vertical") >= 0.1f)
            ani.SetBool("up", true);
        else
            ani.SetBool("up", false);

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    // 프리팹 위치 방향 생성
        //    Instantiate(bullet, pos.position, Quaternion.identity);
        //}
        //InvokeRepeating("Shoot", 0.1f, 10f);
        if (Input.GetKey(KeyCode.Space) && ch)
        {
            ch = false;
            StartCoroutine(Shoot());
        }

        if (Input.GetKey(KeyCode.F))
        {
            gValue += Time.deltaTime;
            gage.fillAmount = gValue;

            if (gValue >= 1)
            {
                GameObject go = Instantiate(lazer, pos.position, Quaternion.identity);

                Destroy(go, 3);
                gValue = 0;
            }
        }
        else
        {
            gValue -= Time.deltaTime;

            if (gValue <= 0)
            {
                gValue = 0;
            }
            // UI
            gage.fillAmount = gValue;
        }

        transform.Translate(moveX, moveY, 0);

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MBullet"))
        {
            hp--;
            StartCoroutine(ChangeColor());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BossBullet"))
        {
            hp--;
            StartCoroutine(ChangeColor());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("아이템");

            pow++;

            if (pow >= 3)
                pow = 3;

            Destroy(collision.gameObject);
        }

    }

    public int GetDamage()
    {
        return damage;
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        // 프리팹 위치 방향 생성
        Instantiate(bullet[pow], pos.position, Quaternion.identity);

        ch = true;
    }

}
