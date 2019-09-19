using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Transform carryPosition;
    public int direction = Constants.Direction.Down;
    public float moveSpeed = 12f;
    public float rollSpeed = 24f;
    public float throwSpeed = 36f;

    public Carriable CarriableTarget { get { return carriableTarget; } set { carriableTarget = value; } }
    public Transform CarryPosition { get { return carryPosition; } }
    public Carriable HeldObject { get { return heldObject; } set { heldObject = value; } }
    public Vector2 MoveVector { get { return moveVector; } }
    public ShadowController Shadow { get { return m_Shadow; } }
    public SwordController Sword { get { return m_Sword; } }

    protected Animator m_Animator;
    protected Rigidbody2D m_Rigidbody2D;
    protected ShadowController m_Shadow;
    protected SwordController m_Sword;

    private Carriable carriableTarget;
    private Carriable heldObject;
    private Vector2 moveVector;
    private bool moving;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Shadow = GetComponentInChildren<ShadowController>();
        m_Sword = GetComponentInChildren<SwordController>();
    }

    void Start()
    {
        SceneLinkedSMB<PlayerController>.Initialise(m_Animator, this);
    }

    void FixedUpdate()
    {
        Move(moveVector);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Constants.Layers.Water) {
            m_Animator.Play("Swim");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Constants.Layers.Water) {
            m_Animator.Play("Normal");
        }
    }

    public void CheckForPickup()
    {
        // Raycast to see if a "carryable" object is in front of the player.
        // Press action button to pick it up.
        if (!moving && carriableTarget != null && Input.GetButtonDown("Action")) {
            m_Animator.Play("Pickup");
        }
    }

    public void CheckForRoll()
    {
        if (moving && Input.GetButtonDown("Action")) {
            m_Animator.Play("Roll");
        }
    }

    public void CheckForSword()
    {
        if (Input.GetButtonDown("Sword")) {
            m_Animator.Play("Sword", -1, 0f);
            m_Sword.Swing();
        }
    }

    public void CheckForThrow()
    {
        if (Input.GetButtonDown("Action")) {
            m_Animator.Play("Throw");
        }
    }

    /// <summary>
    /// Gets a Vector2 representation of the player's current direction.
    /// </summary>
    public Vector2 GetDirectionVector()
    {
        switch (direction)
        {
            case Constants.Direction.Right: return new Vector2(1, 0);
            case Constants.Direction.Up:    return new Vector2(0, 1);
            case Constants.Direction.Left:  return new Vector2(-1, 0);
            default:                        return new Vector2(0, -1);
        }
    }

    /// <summary>
    /// Primary movement input logic.
    /// </summary>
    public void Movement()
    {
        int holdL, holdR, holdU, holdD;
        float speed;

        moveVector = Vector2.zero;

        // Get actual key/joystick/button presses for each direction.
        holdL = Input.GetAxisRaw("Horizontal") == -1 ? 1 : 0;
        holdR = Input.GetAxisRaw("Horizontal") == 1 ? 1 : 0;
        holdU = Input.GetAxisRaw("Vertical") == 1 ? 1 : 0;
        holdD = Input.GetAxisRaw("Vertical") == -1 ? 1 : 0;

        // Cancel opposing keys.
        if (holdL == 1 && holdR == 1) {
            holdL = 0;
            holdR = 0;
        }

        if (holdU == 1 && holdD == 1) {
            holdU = 0;
            holdD = 0;
        }

        // Adjust movement speed when moving diagonally.
        if ((holdD == 1 || holdU == 1) && (holdL == 1 || holdR == 1)) {
            speed = (moveSpeed / Mathf.Sqrt(2));
        } else {
            speed = moveSpeed;
        }

        // Set movement vector.
        moveVector = new Vector2((holdR - holdL) * speed, (holdU - holdD) * speed);

        // Determine if moving and set direction.
        switch (holdL + holdR + holdU + holdD) {
            // Not moving.
            case 0:
                moving = false;
            break;
            // Moving.
            case 1:
                moving = true;
                direction = (Constants.Direction.Left) * holdL +
                            (Constants.Direction.Up) * holdU +
                            (Constants.Direction.Down) * holdD;
            break;
            default:
                moving = true;

                switch (direction) {
                    case Constants.Direction.Left:  if (holdR == 1) { direction = Constants.Direction.Right; }   break;
                    case Constants.Direction.Right: if (holdL == 1) { direction = Constants.Direction.Left; }    break;
                    case Constants.Direction.Up:    if (holdD == 1) { direction = Constants.Direction.Down; }    break;
                    default:                        if (holdU == 1) { direction = Constants.Direction.Up; }      break;
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
        moveVector = newMoveVector;

        if (moveVector == Vector2.zero) {
            moving = false;
            m_Animator.SetFloat("Moving", 0);
        }
    }

    /// <summary>
    /// Updates the Animator's moving and facing values.
    /// </summary>
    public void UpdateFacing()
    {
        m_Animator.SetFloat("Moving", moving ? 1 : 0);

        switch (direction) {
            case Constants.Direction.Right:
                m_Animator.SetFloat("FaceX", 1); m_Animator.SetFloat("FaceY", 0);
                m_Sword.SetFacing(1, 0);
            break;
            case Constants.Direction.Up:
                m_Animator.SetFloat("FaceX", 0); m_Animator.SetFloat("FaceY", 1);
                m_Sword.SetFacing(0, 1);
            break;
            case Constants.Direction.Left:
                m_Animator.SetFloat("FaceX", -1); m_Animator.SetFloat("FaceY", 0);
                m_Sword.SetFacing(-1, 0);
            break;
            default:
                m_Animator.SetFloat("FaceX", 0); m_Animator.SetFloat("FaceY", -1);
                m_Sword.SetFacing(0, -1);
            break;
        }

        // Flip if facing right.
        transform.localScale = new Vector2(
            direction == Constants.Direction.Right ? -1 : 1,
            transform.localScale.y
        );
    }

    /// <summary>
    /// Actually moves the player by the given change vector every FixedUpdate.
    /// </summary>
    /// <param name="change">Vector2 to move by.</param>
    private void Move(Vector2 change)
    {
        if (change != Vector2.zero) {
            m_Rigidbody2D.MovePosition(
                m_Rigidbody2D.position + change * Time.deltaTime
            );
        }
    }
}
