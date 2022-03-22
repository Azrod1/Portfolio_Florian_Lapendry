using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    public int giveMoney = 1;

    public HealthBar healthBar;
    public GameObject deathAnimation;
    public GameObject soundDeath;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        healthBar.SetHealth(health);

        if(health <= 0)
        {
            SceneManagement.instance.AddMoney(giveMoney);
            WaveSpawner.instance.enemyInScene--;
            GameObject death = Instantiate(deathAnimation, transform.position, transform.rotation);
            GameObject audio = Instantiate(soundDeath, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(death, 1f);
            Destroy(audio, 1.5f);
        }
    }
}
