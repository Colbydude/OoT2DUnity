using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Carriable : MonoBehaviour
{
    public Vector2 carryOffset;

    public Collider2D Collider2D { get { return m_Collider2D; } }
    public SpriteRenderer SpriteRenderer { get { return m_SpriteRenderer; } }

    protected Collider2D m_Collider2D;
    protected Rigidbody2D m_Rigidbody2D;
    protected SpriteRenderer m_SpriteRenderer;

    private float airTime = 0f;
    private bool hasBeenThrown;
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
            // Have the object "drop" towards the ground while it's in mid-air.
            m_Rigidbody2D.position = m_Rigidbody2D.position - new Vector2(0, Mathf.Lerp(0, 1, throwOffset));

            // @TODO Fix magic numbers.
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

    /// <summary>
    /// Toggles the hasBeenThrown flag without any movement being added.
    /// </summary>
    public void Drop()
    {
        hasBeenThrown = true;
    }

    /// <summary>
    /// Sends the object in the given direction at the given speed.
    /// </summary>
    /// <param name="direction">Direction the object is thrown in.</param>
    /// <param name="speed">Speed the object will travel at.</param>
    public void Throw(int direction, float speed)
    {
        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        switch (direction) {
            case Constants.Direction.Right: SetVelocity(new Vector2(1, 0), speed);  break;
            case Constants.Direction.Up:    SetVelocity(new Vector2(0, 1), speed);  break;
            case Constants.Direction.Left:  SetVelocity(new Vector2(-1, 0), speed); break;
            default:                        SetVelocity(new Vector2(0, -1), speed); break;
        }

        hasBeenThrown = true;
    }

    /// <summary>
    /// Sets the velocity of the object.
    /// </summary>
    /// <param name="velocityVector">Vector2 direction to move the object in.</param>
    /// <param name="speed">Speed the object will travel at.</param>
    private void SetVelocity(Vector2 velocityVector, float speed)
    {
        m_Rigidbody2D.velocity = velocityVector * speed;
    }
}
