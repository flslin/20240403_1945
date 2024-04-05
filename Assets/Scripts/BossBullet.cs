using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 3f;
    Vector2 vec2 = Vector2.down;

    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vec2 * speed * Time.deltaTime);
        //Debug.Log(transform.position);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
