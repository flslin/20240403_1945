using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField] // Á÷·ÄÈ­
    GameObject bossBullet;

    public int hp = 30;
    public float velocity;


    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(1, -1));
    }

    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(-1, -1));
    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BossBullet>().Move(new Vector2(0, -1));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PBullet"))
        {
            StartCoroutine(ChangeColor());
            hp--;
        }

        if (hp == 0)
        {
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>().Head();
            gameObject.SetActive(false);

        }

    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 130 / 255f, 130 / 255f, 255 / 255f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
