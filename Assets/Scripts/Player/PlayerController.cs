using UnityEngine;

[RequireComponent(typeof(Carrier))]
[RequireComponent(typeof(PlayerInputReader))]
public class PlayerController : Actor
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private float _rollSpeed = 24f;
    [Header("Child Controller References")]
    [SerializeField] ShadowController _shadow;
    [SerializeField] SwordController _sword;

    private PlayerAction _action = PlayerAction.None;
    private bool _canUseSword = true;
    private bool _isMovementLocked = false;

    public float MoveSpeed => _moveSpeed;
    public float RollSpeed => _rollSpeed;
    public ShadowController Shadow => _shadow;
    public SwordController Sword => _sword;

    public Carrier Carrier { get; private set; }
    public PlayerInputReader Input { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Carrier = GetComponent<Carrier>();
        Input = GetComponent<PlayerInputReader>();
    }

    private void OnEnable()
    {
        Input.ActionPerformed += Input_ActionPerformed;
        Input.SwordPerformed += Input_SwordPerformed;
    }

    private void OnDisable()
    {
        Input.ActionPerformed -= Input_ActionPerformed;
        Input.SwordPerformed -= Input_SwordPerformed;
    }

    private void Start()
    {
        SceneLinkedSMB<PlayerController>.Initialise(Animator, this);
    }

    protected override void FixedUpdate()
    {
        _action = CalculateContextAction();
        CalculateMoveDirection();

        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Layer.Water)
            Animator.Play(PlayerAnimatorHashes.Swim);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == (int)Layer.Water)
            Animator.Play(PlayerAnimatorHashes.Normal);
    }

    /// <summary>
    /// Enable or disable the use of the sword.
    /// </summary>
    public void EnableSwordUse(bool canUse = true)
    {
        _canUseSword = canUse;
    }

    /// <summary>
    /// Prevents the player's input from influencing movement.
    /// </summary>
    public void LockMovement(bool locked = true)
    {
        _isMovementLocked = locked;
    }

    /// <summary>
    /// Set the actor's animator to display the sprite based on direction and moving.
    /// Cascades down to the Sword.
    /// </summary>
    protected override void FaceMoveDirection()
    {
        base.FaceMoveDirection();

        Sword.Animator.SetFacing(_direction.ToVector2());
    }

    /// <summary>
    /// Determine the action that the player can take when pressing the Action button.
    /// </summary>
    private PlayerAction CalculateContextAction()
    {
        int currentState = Animator.GetCurrentAnimatorStateInfo(0).shortNameHash;

        if (currentState == PlayerAnimatorHashes.Normal)
        {
            if (!_isMoving && Carrier.Target != null)
                return PlayerAction.Grab;
            else if (_isMoving)
                return PlayerAction.Attack;
        }
        else if (currentState == PlayerAnimatorHashes.Carry)
            return PlayerAction.Throw;

        return PlayerAction.None;
    }

    /// <summary>
    /// Change movement and direction based on input.
    /// </summary>
    private void CalculateMoveDirection()
    {
        if (_isMovementLocked)
            return;

        int holdL, holdR, holdU, holdD;
        float speed;

        SetMoveVector(Vector2.zero);

        // Get actual key/joystick/button presses for each direction.
        holdL = Input.MoveComposite.x == -1 ? 1 : 0;
        holdR = Input.MoveComposite.x == 1 ? 1 : 0;
        holdU = Input.MoveComposite.y == 1 ? 1 : 0;
        holdD = Input.MoveComposite.y == -1 ? 1 : 0;

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
        SetMoveVector(new Vector2((holdR - holdL) * speed, (holdU - holdD) * speed));

        // Determine if moving and set direction.
        switch (holdL + holdR + holdU + holdD)
        {
            // Not moving.
            case 0:
                _isMoving = false;
                break;
            // Moving.
            case 1:
                _isMoving = true;
                _directionAngle = ((int)Direction.Left) * holdL +
                            ((int)Direction.Up) * holdU +
                            ((int)Direction.Down) * holdD;
                break;
            default:
                switch ((Direction)_directionAngle)
                {
                    case Direction.Left: if (holdR == 1) { _directionAngle = (int)Direction.Right; } break;
                    case Direction.Right: if (holdL == 1) { _directionAngle = (int)Direction.Left; } break;
                    case Direction.Up: if (holdD == 1) { _directionAngle = (int)Direction.Down; } break;
                    default: if (holdU == 1) { _directionAngle = (int)Direction.Up; } break;
                }
                break;
        }
    }

    #region Event Handlers

    private void Input_ActionPerformed()
    {
        switch (_action)
        {
            case PlayerAction.Attack:
                Animator.Play(PlayerAnimatorHashes.Roll);
                break;
            case PlayerAction.Grab:
                Animator.Play(PlayerAnimatorHashes.Pickup);
                break;
            case PlayerAction.Throw:
                Animator.Play(PlayerAnimatorHashes.Throw);
                break;
        }
    }

    private void Input_SwordPerformed()
    {
        if (!_canUseSword)
            return;

        Animator.Play(PlayerAnimatorHashes.Sword, -1, 0f);
        Sword.Swing();
    }

    #endregion
}
