using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public int damage;
    [SerializeField] float knockbackForce = 5f;
    [SerializeField] float knockbackDuration = 0.5f;
    Transform playerTransform;
    bool death = false;
    bool isKnockedBack = false;
    float knockbackTimer = 0f;
    Rigidbody2D rb;

    void RandomEnemy()
    {
        transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0);
    }
    void Start()
    {
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnPlayerDeath()
    {
        death = true;
    }

    void Spawn2()
    {
        GameEvents.EnemySpawn.Invoke();
    }
    void Update()
    {
        Vector3 directionToPlayer = Vector3.zero;

        directionToPlayer = playerTransform.position - transform.position;

        directionToPlayer = directionToPlayer.normalized;

        if (death)
        {
            transform.position -= directionToPlayer * speed * Time.deltaTime;
        }
        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;  // Reducir el temporizador

            // Si el knockback ha terminado
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;  // Finaliza el knockback
                rb.velocity = Vector2.zero;  // Detén el movimiento residual
            }
        }
        else
        {
            // Si no está en knockback, perseguir al jugador
            directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer = directionToPlayer.normalized;

            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Hurt(damage);
            Spawn2();
            GameObject.Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            ApplyKnockback(collision.transform.position);
            SwordBehavior knockback = collision.gameObject.GetComponent<SwordBehavior>();
            //knockback.ApplyKnockbackPlayer(collision.GetContacts().point);
        }
    }

    void ApplyKnockback(Vector3 attackerPosition)
    {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;

        Vector2 knockbackDirection = (transform.position - attackerPosition).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}