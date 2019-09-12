using UnityEngine;

public class Carriable : MonoBehaviour
{
    public Vector2 carryOffset;

    protected Collider2D m_Collider2D;
    protected SpriteRenderer m_SpriteRenderer;

    void Awake()
    {
        m_Collider2D = GetComponent<Collider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DisableCollider()
    {
        m_Collider2D.enabled = false;
    }

    public void EnableCollider()
    {
        m_Collider2D.enabled = true;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return m_SpriteRenderer;
    }
}
