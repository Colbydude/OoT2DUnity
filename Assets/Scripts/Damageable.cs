using System;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [Serializable]
    public class DamageEvent : UnityEvent<Damager, Damageable>
    { }

    public int startingHealth = 1;
    public bool destroyOnDeath = false;
    public DamageEvent OnTakeDamage;
    public DamageEvent OnDie;

    public int CurrentHealth { get { return currentHealth; } }

    private int currentHealth;

    void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(Damager damager)
    {
        currentHealth -= damager.damage;

        OnTakeDamage.Invoke(damager, this);

        if (currentHealth <= 0) {
            OnDie.Invoke(damager, this);

            if (destroyOnDeath) {
                Destroy(gameObject);
            }
        }
    }
}
