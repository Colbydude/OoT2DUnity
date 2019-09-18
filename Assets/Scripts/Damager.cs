using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Damager : MonoBehaviour
{
    [Serializable]
    public class DamageableEvent : UnityEvent<Damager, Damageable>
    { }

    [Serializable]
    public class NonDamageableEvent : UnityEvent<Damager>
    { }

    public int damage = 1;
    [Tooltip("If disabled, the damager will ignore triggers when casting for damage.")]
    public bool canHitTriggers;
    public LayerMask hittableLayers;
    public DamageableEvent OnDamageableHit;
    public NonDamageableEvent OnNonDamageableHit;

    public Collider2D LastHit { get { return lastHit; } }

    protected BoxCollider2D m_HitBox;

    private ContactFilter2D attackContactFilter;
    private Collider2D[] attackOverlapResults = new Collider2D[10];
    private Collider2D lastHit;

    void Awake()
    {
        m_HitBox = GetComponent<BoxCollider2D>();

        attackContactFilter.layerMask = hittableLayers;
        attackContactFilter.useLayerMask = true;
        attackContactFilter.useTriggers = canHitTriggers;
    }

    void FixedUpdate()
    {
        if (!m_HitBox.enabled) {
            return;
        }

        // Determine if the Damager is overlapping a Damagable object.
        Vector2 scale = transform.lossyScale;
        Vector2 scaledSize = Vector2.Scale(m_HitBox.size, scale);

        Vector2 pointA = (Vector2) m_HitBox.bounds.center - scaledSize * 0.5f;
        Vector2 pointB = pointA + scaledSize;

        int hitCount = Physics2D.OverlapArea(pointA, pointB, attackContactFilter, attackOverlapResults);

        for (int i = 0; i < hitCount; i++) {
            lastHit = attackOverlapResults[i];
            Damageable damageable = lastHit.GetComponent<Damageable>();

            if (damageable) {
                OnDamageableHit.Invoke(this, damageable);
                damageable.TakeDamage(this);
            } else {
                OnNonDamageableHit.Invoke(this);
            }
        }
    }
}
