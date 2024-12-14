using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] TMP_Text playerHealthUI;
    public float currentHealth;
    [SerializeField] Image reduceLife;
    

    void Start()
    {
        currentHealth = maxHealth;
        reduceLife.fillAmount = 1f;
    }

    public void Hurt(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameEvents.PlayerDied.Invoke();
        }
        UpdateHealth();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealth();
    }

    void UpdateHealth()
    {
        playerHealthUI.text = currentHealth.ToString();
        reduceLife.fillAmount = currentHealth / maxHealth;
    }
}