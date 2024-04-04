using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnStop = 20f;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject enemy2;

    bool swi = true;
    bool swi2 = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
        Invoke("Stop", spawnStop);
    }

    IEnumerator spawn()
    {
        while (swi)
        {
            float spawn = Random.Range(-2.3f, 2.3f);
            Instantiate(enemy, new Vector2(spawn, transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }

    private void Stop()
    {
        swi = false;
        StopCoroutine(spawn());
        // 두번째 몬스터
        StartCoroutine(spawn2());
        Invoke("Stop2", spawnStop + 10);
    }

    IEnumerator spawn2()
    {
        while (swi2)
        {
            float spawn = Random.Range(-2.3f, 2.3f);
            Instantiate(enemy2, new Vector2(spawn, transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(4f);
        }
    }

    private void Stop2()
    {
        swi2 = false;
        StopCoroutine(spawn2());
    }
}
