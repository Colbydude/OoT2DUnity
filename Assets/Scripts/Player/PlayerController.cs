using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Carrier))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private float _rollSpeed = 24f;
    [Header("Child Controller References")]
    [SerializeField] ShadowController _shadow;
    [SerializeField] SwordController _sword;

    private int _direction = 270;
    private Vector2 _moveVector;
    private bool _moving;

    private Animator _animator;
    private Carrier _carrier;
    private Rigidbody2D _rigidbody;

    public Carrier Carrier => _carrier;
    public Direction Direction => (Direction)_direction;
    public float MoveSpeed => _moveSpeed;
    public Vector2 MoveVector => _moveVector;
    public float RollSpeed => _rollSpeed;
    public ShadowController Shadow => _shadow;
    public SwordController Sword => _sword;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _carrier = GetComponent<Carrier>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SceneLinkedSMB<PlayerController>.Initialise(_animator, this);
    }

    void FixedUpdate()
    {
        Move(_moveVector);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Layers.Water)
            _animator.Play("Swim");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Layers.Water)
            _animator.Play("Normal");
    }

    public void CheckForPickup()
    {
        // If a "carryable" object is in front of the player.
        // Press action button to pick it up.
        if (!_moving && _carrier.Target != null && Input.GetButtonDown("Action"))
            _animator.Play("Pickup");
    }

    public void CheckForRoll()
    {
        if (_moving && Input.GetButtonDown("Action"))
            _animator.Play("Roll");
    }

    public void CheckForSword()
    {
        if (Input.GetButtonDown("Sword"))
        {
            _animator.Play("Sword", -1, 0f);
            _sword.Swing();
        }
    }

    public void CheckForThrow()
    {
        if (Input.GetButtonDown("Action"))
            _animator.Play("Throw");
    }

    /// <summary>
    /// Primary movement input logic.
    /// </summary>
    public void Movement()
    {
        int holdL, holdR, holdU, holdD;
        float speed;

        _moveVector = Vector2.zero;

        // Get actual key/joystick/button presses for each direction.
        holdL = Input.GetAxisRaw("Horizontal") == -1 ? 1 : 0;
        holdR = Input.GetAxisRaw("Horizontal") == 1 ? 1 : 0;
        holdU = Input.GetAxisRaw("Vertical") == 1 ? 1 : 0;
        holdD = Input.GetAxisRaw("Vertical") == -1 ? 1 : 0;

        // Cancel opposing keys.
        if (holdL == 1 && holdR == 1)
        {
            holdL = 0;
            holdR = 0;
        }

        if (holdU == 1 && holdD == 1)
        {
            holdU = 0;
            holdD = 0;
        }

        // Adjust movement speed when moving diagonally.
        if ((holdD == 1 || holdU == 1) && (holdL == 1 || holdR == 1))
            speed = (_moveSpeed / Mathf.Sqrt(2));
        else
            speed = _moveSpeed;

        // Set movement vector.
        _moveVector = new Vector2((holdR - holdL) * speed, (holdU - holdD) * speed);

        // Determine if moving and set direction.
        switch (holdL + holdR + holdU + holdD)
        {
            // Not moving.
            case 0:
                _moving = false;
                break;
            // Moving.
            case 1:
                _moving = true;
                _direction = ((int)Direction.Left) * holdL +
                            ((int)Direction.Up) * holdU +
                            ((int)Direction.Down) * holdD;
                break;
            default:
                _moving = true;

                switch ((Direction)_direction)
                {
                    case Direction.Left: if (holdR == 1) { _direction = (int)Direction.Right; } break;
                    case Direction.Right: if (holdL == 1) { _direction = (int)Direction.Left; } break;
                    case Direction.Up: if (holdD == 1) { _direction = (int)Direction.Down; } break;
                    default: if (holdU == 1) { _direction = (int)Direction.Up; } break;
                }
                break;
        }
    }

    /// <summary>
    /// Manually set the movement vector.
    /// </summary>
    /// <param name="newMoveVector">The movement vector to set.</param>
    public void SetMoveVector(Vector2 newMoveVector)
    {
        _moveVector = newMoveVector;

        if (_moveVector == Vector2.zero)
        {
            _moving = false;
            _animator.SetFloat("Moving", 0);
        }
    }

    /// <summary>
    /// Updates the Animator's moving and facing values.
    /// </summary>
    public void UpdateFacing()
    {
        _animator.SetFloat("Moving", _moving ? 1 : 0);
        Vector2 directionVector = Direction.ToVector2();

        _animator.SetFacing(directionVector);
        _carrier.SetDirection(Direction);
        _sword.Animator.SetFacing(directionVector);

        // Flip if facing right.
        transform.localScale = new Vector2(
            _direction == (int)Direction.Right ? -1 : 1,
            transform.localScale.y
        );
    }

    /// <summary>
    /// Actually moves the player by the given change vector every FixedUpdate.
    /// </summary>
    /// <param name="change">Vector2 to move by.</param>
    private void Move(Vector2 change)
    {
        if (change != Vector2.zero)
        {
            _rigidbody.MovePosition(
                _rigidbody.position + change * Time.deltaTime
            );
        }
    }
}
