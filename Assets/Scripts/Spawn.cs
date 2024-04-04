using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //public float spawnSpeed = 1f;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            float spawn = Random.Range(-2.3f, 2.3f);
            Instantiate(enemy, new Vector2(spawn, transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }

}
