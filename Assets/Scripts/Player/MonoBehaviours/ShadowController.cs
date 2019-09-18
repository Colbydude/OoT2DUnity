using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowController : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get { return m_SpriteRenderer; } }

    protected SpriteRenderer m_SpriteRenderer;

    void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
