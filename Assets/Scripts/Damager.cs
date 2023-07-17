using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Damager : MonoBehaviour
{
    [SerializeField] protected int _damage = 1;
    [Tooltip("If disabled, the damager will ignore triggers when casting for damage.")]
    [SerializeField] protected bool _canHitTriggers;
    [SerializeField] protected LayerMask _hittableLayers;

    private ContactFilter2D _attackContactFilter;
    private Collider2D[] _attackOverlapResults = new Collider2D[10];
    private Collider2D _lastHit;

    protected BoxCollider2D _hitBox;

    public int Damage => _damage;
    public Collider2D LastHit => _lastHit;

    public UnityEvent<Damager, Damageable> DamageableHit;
    public UnityEvent<Damager> NonDamageableHit;

    protected void Awake()
    {
        _hitBox = GetComponent<BoxCollider2D>();

        _attackContactFilter.layerMask = _hittableLayers;
        _attackContactFilter.useLayerMask = true;
        _attackContactFilter.useTriggers = _canHitTriggers;
    }

    protected void FixedUpdate()
    {
        if (!_hitBox.enabled)
            return;

        // Determine if the Damager is overlapping a Damagable object.
        Vector2 scale = transform.lossyScale;
        Vector2 scaledSize = Vector2.Scale(_hitBox.size, scale);

        Vector2 pointA = (Vector2)_hitBox.bounds.center - scaledSize * 0.5f;
        Vector2 pointB = pointA + scaledSize;

        int hitCount = Physics2D.OverlapArea(pointA, pointB, _attackContactFilter, _attackOverlapResults);

        for (int i = 0; i < hitCount; i++)
        {
            _lastHit = _attackOverlapResults[i];
            Damageable damageable = _lastHit.GetComponent<Damageable>();

            if (damageable)
            {
                DamageableHit?.Invoke(this, damageable);
                damageable.TakeDamage(this);
            }
            else
                NonDamageableHit?.Invoke(this);
        }
    }
}
