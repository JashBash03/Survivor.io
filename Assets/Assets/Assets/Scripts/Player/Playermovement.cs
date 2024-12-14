using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Playermovement: MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float friction = 5f;
    bool gameOver = false;
    Rigidbody2D rb;

    private void Start()
    {
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
        rb = GetComponent<Rigidbody2D>();
    }

    void OnPlayerDeath()
    {
        gameOver = true;
    }

    void Update()
    {
        if (gameOver)
            return;

        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y -= 1;
        }
        else if (movement == Vector2.zero)
        {
            rb.velocity = new Vector2(
                movement.x / (1 + friction * Time.deltaTime),
                movement.y / (1 + friction * Time.deltaTime));
        }

        rb.velocity += movement * speed * Time.deltaTime;
    }
}
