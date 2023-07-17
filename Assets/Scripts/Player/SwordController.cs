using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Damager))]
[RequireComponent(typeof(SpriteRenderer))]
public class SwordController : MonoBehaviour
{
    protected Animator _animator;
    protected Collider2D _collider;
    protected SpriteRenderer _renderer;

    public Animator Animator => _animator;
    public Collider2D Collider => _collider;
    public SpriteRenderer Renderer => _renderer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Start the sword swinging animation.
    /// </summary>
    public void Swing()
    {
        _animator.Play("Swing", -1, 0f);
    }
}
