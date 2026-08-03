using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int currentHealth;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public bool IsDead => currentHealth <= 0;

    public UnityEvent<int, int> HealthChangedEvent; // (current, max) — for UI updates
    public UnityEvent DiedEvent;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        HealthChangedEvent.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
            DiedEvent.Invoke();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        HealthChangedEvent.Invoke(currentHealth, maxHealth);
    }
}