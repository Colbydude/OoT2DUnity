using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Actor : MonoBehaviour
{
    protected int _directionAngle = 270;
    protected Direction _direction => (Direction)_directionAngle;
    protected bool _isDirectionLocked;
    protected bool _isMoving;
    protected Vector2 _moveVector;

    public Direction Direction => _direction;

    public Animator Animator { get; private set; }
    public Collider2D Collider { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }
    public SpriteRenderer Renderer { get; private set; }

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<Collider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void FixedUpdate()
    {
        FaceMoveDirection();
        Move(_moveVector);
    }

    /// <summary>
    /// Set the actor's animator to display the sprite based on direction and moving.
    /// </summary>
    protected virtual void FaceMoveDirection()
    {
        Animator.SetFloat(ActorAnimatorHashes.Moving, _isMoving ? 1 : 0);

        if (_isDirectionLocked)
            return;

        Animator.SetFacing(_direction.ToVector2());

        // Flip if facing right.
        transform.localScale = new Vector2(
            _direction == (int)Direction.Right ? -1 : 1,
            transform.localScale.y
        );
    }

    /// <summary>
    /// Move the actor by the given amount of change.
    /// </summary>
    protected void Move(Vector2 change)
    {
        if (change != Vector2.zero)
        {
            _isMoving = true;
            Rigidbody.MovePosition(
                Rigidbody.position + _moveVector * Time.deltaTime
            );
        }
        else
            _isMoving = false;
    }

    /// <summary>
    /// Lock the direction that the actor is facing.
    /// </summary>
    public void LockDirection(bool locked = true)
    {
        _isDirectionLocked = locked;
    }

    /// <summary>
    /// Set the actor to move by the given vector.
    /// </summary>
    public void SetMoveVector(Vector2 moveVector)
    {
        _moveVector = moveVector;
    }

    /// <summary>
    /// Stop the actor's movements.
    /// </summary>
    public void StopMoving()
    {
        _moveVector = Vector2.zero;
    }
}
