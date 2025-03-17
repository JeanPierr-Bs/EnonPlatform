using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            Debug.Log("Vida: " + currentHealth);
        }
    }
    public void Heal(int amount)
    {
        if (amount > 0)
        {
            currentHealth += amount;
            currentHealth = Mathf.Min(currentHealth + amount,maxHealth);
            UiManager.Instance.UpdateHealth(currentHealth);
            Debug.Log("Vida: " + currentHealth);
        }
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
