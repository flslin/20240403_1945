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
    [SerializeField]
    private GameObject boss;

    bool swi = true;
    bool swi2 = true;

    [SerializeField]
    GameObject textBossWarning; // 보스 둥장 텍스트 오브젝트

    private void Awake()
    {
        textBossWarning.SetActive(false);
    }

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
        // 보스몬스터
        textBossWarning.SetActive(true);

        Vector3 pos = new Vector3(0, 3, 0);
        Instantiate(boss, pos, Quaternion.identity);
    }
}
