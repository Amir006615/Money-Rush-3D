using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public double Damage;
    private void Start()
    {
        // Destruction of the Bullet
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // shooting speed
        transform.position += Vector3.forward * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Damage Enemy
        if (collision.tag == "Enemy")
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage((float)(1 + Damage));
            }
            // start EnemyAnimation
            healthComponent.EnemyAnimation();

            // to deactivate gameObject
            gameObject.SetActive(false);
        }

        if(collision.tag == "BulletFinish")
        {
            // to deactivate gameObject
            gameObject.SetActive(false);
        }
    }

}
