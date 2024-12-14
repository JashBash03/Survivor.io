using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] int healAmount;

    void RandomLocation()
    {
        float XAxis = Random.Range(-8.5f, 8.5f);
        float YAxis = Random.Range(-4.5f, 4.5f);
        transform.position = new Vector2(XAxis, YAxis);
    }
    void Start()
    {
        RandomLocation();
    }

    void Spawn2()
    {
        GameEvents.EnemySpawn.Invoke();
        GameEvents.EnemySpawn.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Heal(healAmount);
            GameEvents.CollectItem.Invoke();
            Spawn2();
            RandomLocation();
        }
    }
}
