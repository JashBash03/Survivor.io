using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 6f;
    [SerializeField] ParticleSystem particles;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        particles.Stop();
    }

    void Spawn3()
    {
        GameEvents.EnemySpawn.Invoke();
    }

    public void EnemyHurt(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameEvents.EnemyDied.Invoke();
            Destroy(gameObject);
            Spawn3();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            EnemyHurt(2);
            particles.Play();
            particles.Stop();
        }
    }
}