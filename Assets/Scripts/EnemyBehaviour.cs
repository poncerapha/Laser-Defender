using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
    public float health = 150f;
    public float speed = 10f;
    public float shotsPerSeconds = 0.5f;
    public GameObject projectile;


    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if(Random.value < probability)
        {
            Fire();
        }
        
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity);
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.getDamage();
            missile.Hit();
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }

}
