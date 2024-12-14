using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Transform Player;
    bool gameOver = false;
    [SerializeField]Transform playerTransform;
    float speed;

    void Start()
    {
        GameEvents.EnemySpawn.AddListener(Spawn);
        GameEvents.EnemySpawn.Invoke();
        GameEvents.EnemySpawn.Invoke();
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
    }

    void OnPlayerDeath()
    {
        gameOver = true;
        Vector3 directionToPlayer = Vector3.zero;
        directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;
        transform.position = directionToPlayer * speed * Time.deltaTime;
    }

    void Spawn()
    {
        if (gameOver)
            return;
            GameObject.Instantiate(prefab, new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), Quaternion.identity);
    }
}
