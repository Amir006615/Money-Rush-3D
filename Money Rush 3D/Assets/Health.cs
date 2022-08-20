using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private bool g;
    private Animator anim;
    private double Action = 0.05;
    private float TimeConuter;

    public Image fillImage;
    public Slider Slider;
    public GameObject HealthBar;
    private float TimeConuterHealthBar;

    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HealthBar.SetActive(false);

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

        TimeConuterHealthBar -= Time.deltaTime;
        if (TimeConuterHealthBar <= 0)
        {
            TimeConuterHealthBar = 2;
            HealthBar.SetActive(false);
        }

        if (Slider.value <= Slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (Slider.value > Slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = currentHealth / maxHealth;
        if (fillValue <= Slider.maxValue / 10)
        {
            fillImage.color = Color.blue;
        }
        if (fillValue <= Slider.maxValue / 50)
        {
            fillImage.color = Color.black;
        }
        Slider.value = fillValue;

    }

    // Damage Enemy
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            HealthBar.SetActive(false);
            Game.Instance.Coins += coin;
        }
    }
    // play Animation
    public void EnemyAnimation()
    {
        anim.SetBool("Enemy Animation", true);
        HealthBar.SetActive(true);
        TimeConuterHealthBar = 2;
        g = true;
    }
}
