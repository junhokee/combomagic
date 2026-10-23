using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int currentHealth;
    [SerializeField] private int shield;
    public HealthBar healthBar;
    public int Shield => shield;
    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    
    public bool IsDead => currentHealth <= 0;


    public UnityEvent<int, int> HealthChangedEvent; // (current, max) — for UI updates
    public UnityEvent DiedEvent;

    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if(shield > amount)
        {
            shield -= amount;
        }
        else
        {
            amount -= shield;
            shield = 0;
        }
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        HealthChangedEvent.Invoke(currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
            DiedEvent.Invoke();
    }
    public void GainShield(int amount)
    {
        shield += amount;
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        HealthChangedEvent.Invoke(currentHealth, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void SetMaxHealth(int amount)
    {
        maxHealth = amount;
    }
}