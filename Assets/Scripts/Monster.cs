using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3;
    public float delay = 1;
    public Transform p1;
    public Transform p2;
    public GameObject mBullet;

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
}
