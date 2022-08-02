using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    private Animator anim;
    private double Action = 0.05;
    private float TimeConuter;
    public bool g;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (g)
        {
            // play Animation
            TimeConuter -= Time.deltaTime;
            if (TimeConuter <= 0)
            {
                TimeConuter = (float)Action;
                anim.SetBool("Enemy Animation", false);
                SoundManager.playSound("bullet");
                g = false;
            }
        }
    }

    // Damage Enemy
    public void TakeDamage(float amount)
   {
        currentHealth -= amount;
        
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
   }
    // play Animation
    public void EnemyAnimation()
    {
        anim.SetBool("Enemy Animation", true);
        g = true;
    }
}
