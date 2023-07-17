using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Carriable : Actor
{
    [SerializeField] protected Vector2 _carryOffset;
    [SerializeField] protected float _throwSpeed = 36;

    protected float _airTime = 0f;
    protected bool _hasBeenThrown;
    protected float _throwOffset = 0;

    public Vector2 CarryOffset => _carryOffset;

    protected override void FixedUpdate()
    {
        if (_hasBeenThrown)
        {
            // Have the object "drop" towards the ground while it's in mid-air.
            Rigidbody.position = Rigidbody.position - new Vector2(0, Mathf.Lerp(0, 1, _throwOffset));

            // @TODO: Fix magic numbers.
            if (transform.forward.normalized.y == -1)
                _throwOffset += 0.25f * Time.deltaTime;
            else
                _throwOffset += 1f * Time.deltaTime;

            _airTime += 3.5f * Time.deltaTime;

            if (_airTime >= 1.0f)
                Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Destroys the object when it collides after being thrown.
    /// </summary>
    /// <param name="collision">Collision2D data about the collision that just occurred.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasBeenThrown)
            Destroy(this.gameObject);
    }

    /// <summary>
    /// Toggles the hasBeenThrown flag without any movement being added.
    /// </summary>
    public void Drop()
    {
        _hasBeenThrown = true;
    }

    /// <summary>
    /// Sets the velocity of the object.
    /// </summary>
    /// <param name="velocityVector">Vector2 direction to move the object in.</param>
    /// <param name="speed">Speed the object will travel at.</param>
    private void SetVelocity(Vector2 velocityVector, float speed)
    {
        Rigidbody.velocity = velocityVector * speed;
    }

    /// <summary>
    /// Sends the object in the given direction at the given speed.
    /// </summary>
    /// <param name="direction">Direction the object is thrown in.</param>
    /// <param name="speed">Speed the object will travel at.</param>
    public void Throw(Direction direction)
    {
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        SetVelocity(direction.ToVector2(), _throwSpeed);

        _hasBeenThrown = true;
    }
}
