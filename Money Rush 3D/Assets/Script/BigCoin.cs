using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    public GunController Gun;
    public float speed;


    private void Start()
    {
        // Destruction of the BigCoin
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // shooting speed
        transform.position += Vector3.forward * speed * Time.deltaTime;
        // Rotate
        transform.Rotate(500f * Time.deltaTime, 0f, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // The amount of damages
        if (collision.tag == "Enemy")
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(100000);
            }
        }

        if (collision.tag == "BulletFinish")
        {
            // to deactivate gameObject
            gameObject.SetActive(false);
        }
    }
}
