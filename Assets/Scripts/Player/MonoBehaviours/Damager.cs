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

    public Collider2D LastHit { get { return m_LastHit; } }

    public int damage = 1;
    [Tooltip("If disabled, the damager will ignore triggers when casting for damage.")]
    public bool canHitTriggers;
    public LayerMask hittableLayers;
    public DamageableEvent OnDamageableHit;
    public NonDamageableEvent OnNonDamageableHit;

    protected ContactFilter2D m_AttackContactFilter;
    protected Collider2D[] m_AttackOverlapResults = new Collider2D[10];
    protected Transform m_DamagerTransform;
    protected BoxCollider2D m_HitBox;
    public Collider2D m_LastHit;

    void Awake()
    {
        m_AttackContactFilter.layerMask = hittableLayers;
        m_AttackContactFilter.useLayerMask = true;
        m_AttackContactFilter.useTriggers = canHitTriggers;

        m_HitBox = GetComponent<BoxCollider2D>();

        m_DamagerTransform = transform;
    }

    void FixedUpdate()
    {
        if (!m_HitBox.enabled) {
            return;
        }

        Vector2 scale = m_DamagerTransform.lossyScale;
        Vector2 scaledSize = Vector2.Scale(m_HitBox.size, scale);

        Vector2 pointA = (Vector2) m_HitBox.bounds.center - scaledSize * 0.5f;
        Vector2 pointB = pointA + scaledSize;

        int hitCount = Physics2D.OverlapArea(pointA, pointB, m_AttackContactFilter, m_AttackOverlapResults);

        for (int i = 0; i < hitCount; i++) {
            m_LastHit = m_AttackOverlapResults[i];
            Damageable damageable = m_LastHit.GetComponent<Damageable>();

            if (damageable) {
                OnDamageableHit.Invoke(this, damageable);
                damageable.TakeDamage(this);
            } else {
                OnNonDamageableHit.Invoke(this);
            }
        }
    }
}
