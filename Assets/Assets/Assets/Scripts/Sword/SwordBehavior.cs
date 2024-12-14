using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform Sword;
    [SerializeField] float speed = 10f;
    [SerializeField] float knockbackForce = 5f;
    [SerializeField] float knockbackDuration = 0.5f;
    Vector2 rotation;
    bool isKnockedBack = false;
    float knockbackTimer = 0f;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sword.RotateAround(rb.position, Vector3.forward, speed * Time.deltaTime);
        print(Sword.position);
    }
    public void ApplyKnockbackPlayer(Vector3 attackerPosition)
    {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
        print("Estoy colisionando");
        Vector2 knockbackDirection = (Player.position - attackerPosition).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
