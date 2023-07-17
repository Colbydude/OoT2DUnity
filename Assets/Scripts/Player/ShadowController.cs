using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowController : MonoBehaviour
{
    private SpriteRenderer _renderer;

    public SpriteRenderer Renderer => _renderer;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
}
