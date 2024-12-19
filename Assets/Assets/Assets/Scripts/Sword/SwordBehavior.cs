using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform swordRoot;
    [SerializeField] float speed = 10f;
    [SerializeField] float knockbackForce = 5f;
    [SerializeField] float knockbackDuration = 0.5f;
    Vector2 rotation;
    bool isKnockedBack = false;
    float knockbackTimer = 0f;
    [SerializeField] Rigidbody2D rb;

    Vector3 initialPosition;

    GottaGoFast spin;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = initialPosition;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Rotation(spin.speedMultiplier);
        }
        else
        {
            Rotation(1);
        }
    }

    public void Rotation(float multiplier)
    {
        swordRoot.Rotate(0, 0, speed * multiplier * Time.deltaTime);
    }
    public void ApplyKnockbackPlayer(Vector3 attackerPosition)
    {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
        print("Estoy colisionando");
        Vector2 knockbackDirection = (player.position - attackerPosition).normalized;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
