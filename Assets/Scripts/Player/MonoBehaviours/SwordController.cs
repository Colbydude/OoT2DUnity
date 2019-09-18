using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Damager))]
[RequireComponent(typeof(SpriteRenderer))]
public class SwordController : MonoBehaviour
{
    public Animator Animator { get { return m_Animator; } }
    public Collider2D Collider2D { get { return m_Collider; } }
    public SpriteRenderer SpriteRenderer { get { return m_SpriteRenderer; } }

    protected Animator m_Animator;
    protected Collider2D m_Collider;
    protected SpriteRenderer m_SpriteRenderer;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Collider = GetComponent<Collider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Set the animator's facing values.
    /// </summary>
    /// <param name="x">X facing.</param>
    /// <param name="y">Y facing.</param>
    public void SetFacing(int x, int y)
    {
        m_Animator.SetFloat("FaceX", x);
        m_Animator.SetFloat("FaceY", y);
    }

    /// <summary>
    /// Start the sword swinging animation.
    /// </summary>
    public void Swing()
    {
        m_Animator.Play("Swing", -1, 0f);
    }
}
