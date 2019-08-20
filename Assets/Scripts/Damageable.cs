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

    protected int m_CurrentHealth;

    public int CurrentHealth { get { return m_CurrentHealth; } }

    void OnEnable()
    {
        m_CurrentHealth = startingHealth;
    }

    public void TakeDamage(Damager damager)
    {
        m_CurrentHealth -= damager.damage;

        OnTakeDamage.Invoke(damager, this);

        if (m_CurrentHealth <= 0) {
            OnDie.Invoke(damager, this);

            if (destroyOnDeath) {
                Destroy(gameObject);
            }
        }
    }
}
