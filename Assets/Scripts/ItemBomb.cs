using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBomb : MonoBehaviour
{
    public GameObject bomb;
    public float moveX;
    public float moveY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(moveX, moveY));
    }


}
