using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;
    public float lifespan = 3f;
    public int damage = 5;
    private Rigidbody2D rbBullet;

    void Awake()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // rbBullet.AddForce(transform.forward * speed, ForceMode2D.Impulse);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
    
}
