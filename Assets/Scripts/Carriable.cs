using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Carriable : MonoBehaviour
{
    public Vector2 carryOffset;

    protected Collider2D m_Collider2D;
    protected Rigidbody2D m_Rigidbody2D;
    protected SpriteRenderer m_SpriteRenderer;

    private bool hasBeenThrown;

    private float airTime = 0f;
    private float throwOffset = 0;

    void Awake()
    {
        m_Collider2D = GetComponent<Collider2D>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (hasBeenThrown) {
            m_Rigidbody2D.position = m_Rigidbody2D.position - new Vector2(0, Mathf.Lerp(0, 1, throwOffset));

            if (transform.forward.normalized.y == -1) {
                throwOffset += 0.25f * Time.deltaTime;
            } else {
                throwOffset += 1f * Time.deltaTime;
            }

            airTime += 3.5f * Time.deltaTime;

            if (airTime >= 1.0f) {
                Destroy(this.gameObject);
            }
        }
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

    public void SetVelocity(Vector2 velocityVector, float speed)
    {
        m_Rigidbody2D.velocity = velocityVector * speed;
    }

    public void Throw(int direction, float speed)
    {
        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        switch (direction) {
            case 0: SetVelocity(new Vector2(1, 0), speed); break;
            case 90: SetVelocity(new Vector2(0, 1), speed); break;
            case 180: SetVelocity(new Vector2(-1, 0), speed); break;
            default: SetVelocity(new Vector2(0, -1), speed); break;
        }

        hasBeenThrown = true;
    }
}
