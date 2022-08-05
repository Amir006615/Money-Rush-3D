using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCoin : MonoBehaviour
{
    public GunController Gun;
    public float speed;

    private void Start()
    {
        // Destruction of the BombCoin
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // shooting speed
        transform.position += Vector3.forward * speed * Time.deltaTime;
        // Rotate
        transform.Rotate(1000f * Time.deltaTime, 0f, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // The amount of damages
        if (collision.tag == "Enemy")
        {
            var healthComponent = collision.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(200);
            }

            // to deactivate gameObject
            gameObject.SetActive(false);
        }

        if (collision.name == "Grond")
        {
            // Explosion  // Unfinished
            gameObject.GetComponent<SphereCollider>().radius = 6;
        }

    }
}
