using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField] protected int _startingHealth = 1;
    [SerializeField] protected bool _destroyOnDeath = false;

    protected int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public UnityEvent<Damager, Damageable> DamageTaken;
    public UnityEvent<Damager, Damageable> Died;

    protected void Awake()
    {
        _currentHealth = _startingHealth;
    }

    /// <summary>
    /// Have the object take damage and invoke the necessary events.
    /// </summary>
    /// <param name="damager">The object this object is being damaged by.</param>
    public void TakeDamage(Damager damager)
    {
        _currentHealth -= damager.Damage;

        DamageTaken?.Invoke(damager, this);

        if (_currentHealth <= 0)
        {
            Died?.Invoke(damager, this);

            if (_destroyOnDeath)
                Destroy(gameObject);
        }
    }
}
