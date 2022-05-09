using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("bullet"));
            timer = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
            Destroy(GameObject.FindGameObjectWithTag("bullet"));
        }
    }
}
