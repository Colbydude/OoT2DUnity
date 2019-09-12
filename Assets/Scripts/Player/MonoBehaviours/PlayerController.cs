using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public enum Direction {
        Right = 0,
        Up = 90,
        Left = 180,
        Down = 270
    }

    public int direction = (int) Direction.Down;
    public float moveSpeed = 12f;
    public float rollSpeed = 24f;

    protected Animator m_Animator;
    protected Rigidbody2D m_Rigidbody2D;
    protected Vector2 m_MoveVector;
    protected bool m_Moving;

    protected Transform m_Shadow_Transform;

    protected Animator m_Sword_Animator;
    protected Transform m_Sword_Transform;

    protected Transform m_Carry_Position;
    protected Carriable m_Carriable_Target;
    protected Carriable m_Held_Object;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        m_Shadow_Transform = transform.Find("Shadow");

        m_Sword_Transform = transform.Find("Sword");
        m_Sword_Animator = m_Sword_Transform.GetComponent<Animator>();

        m_Carry_Position = transform.Find("CarryPosition");
    }

    void Start()
    {
        SceneLinkedSMB<PlayerController>.Initialise(m_Animator, this);
    }

    void FixedUpdate()
    {
        Move(m_MoveVector);
    }

    private void Move(Vector2 change)
    {
        if (change != Vector2.zero)
        {
            m_Rigidbody2D.MovePosition(
                m_Rigidbody2D.position + change * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4) {
            m_Animator.Play("Swim");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 4) {
            m_Animator.Play("Normal");
        }
    }

    // Public functions - called mostly by StateMachineBehaviours.
    public Vector2 GetDirectionVector()
    {
        switch (direction) {
            case (int) Direction.Right: return new Vector2(1, 0);
            case (int) Direction.Up:    return new Vector2(0, 1);
            case (int) Direction.Left:  return new Vector2(-1, 0);
            default:                    return new Vector2(0, -1);
        }
    }

    public void CheckForPickup()
    {
        // Raycast to see if a "carryable" object is in front of you.
        // Press action button to pick it up.
        if (!m_Moving && m_Carriable_Target != null && Input.GetButtonDown("Action")) {
            m_Animator.Play("Pickup");
        }
    }

    public void CheckForRoll()
    {
        if (m_Moving && Input.GetButtonDown("Action")) {
            m_Animator.Play("Roll");
        }
    }

    public void CheckForSword()
    {
        if (Input.GetButtonDown("Sword")) {
            m_Animator.Play("Sword", -1, 0f);
            m_Sword_Animator.Play("Swing", -1, 0f);
        }
    }

    public void CheckForThrow()
    {
        if (Input.GetButtonDown("Action")) {
            m_Animator.Play("Throw");
        }
    }

    public Carriable GetCarriableTarget()
    {
        return m_Carriable_Target;
    }

    public Transform GetCarryPosition()
    {
        return m_Carry_Position;
    }

    public Carriable GetHeldObject()
    {
        return m_Held_Object;
    }

    public Vector2 GetMoveVector()
    {
        return m_MoveVector;
    }

    public Transform GetShadowTransform()
    {
        return m_Shadow_Transform;
    }

    public Transform GetSwordTransform()
    {
        return m_Sword_Transform;
    }

    public void Movement()
    {
        int holdL, holdR, holdU, holdD;
        float speed;
        m_MoveVector = Vector2.zero;

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
        m_MoveVector = new Vector2((holdR - holdL) * speed, (holdU - holdD) * speed);

        // Determine if moving and set direction.
        switch (holdL + holdR + holdU + holdD) {
            // Not moving.
            case 0:
                m_Moving = false;
            break;
            // Moving.
            case 1:
                m_Moving = true;
                direction = ((int) Direction.Left) * holdL + ((int) Direction.Up) * holdU + ((int) Direction.Down) * holdD;
            break;
            default:
                m_Moving = true;

                switch (direction) {
                    case (int) Direction.Left:  if (holdR == 1) { direction = (int) Direction.Right; }   break;
                    case (int) Direction.Right: if (holdL == 1) { direction = (int) Direction.Left; }    break;
                    case (int) Direction.Up:    if (holdD == 1) { direction = (int) Direction.Down; }    break;
                    default:                    if (holdU == 1) { direction = (int) Direction.Up; }      break;
                }
            break;
        }
    }

    public void SetCarriableTarget(Carriable carriable)
    {
        m_Carriable_Target = carriable;
    }

    public void SetHeldObject(Carriable carriable)
    {
        m_Held_Object = carriable;
    }

    public void SetHorizontalMovement(float newHorizontalMovement)
    {
        m_MoveVector.x = newHorizontalMovement;
    }

    public void SetMoveVector(Vector2 newMoveVector)
    {
        m_MoveVector = newMoveVector;

        if (m_MoveVector == Vector2.zero) {
            m_Moving = false;
            m_Animator.SetFloat("Moving", 0);
        }
    }

    public void SetVerticalMovement(float newVerticalMovement)
    {
        m_MoveVector.y = newVerticalMovement;
    }

    public void UpdateFacing()
    {
        if (m_Moving) {
            m_Animator.SetFloat("Moving", 1);
        } else {
            m_Animator.SetFloat("Moving", 0);
        }

        switch (direction) {
            case (int) Direction.Right:
                m_Animator.SetFloat("FaceX", 1); m_Animator.SetFloat("FaceY", 0);
                m_Sword_Animator.SetFloat("FaceX", 1); m_Sword_Animator.SetFloat("FaceY", 0);
            break;
            case (int) Direction.Up:
                m_Animator.SetFloat("FaceX", 0); m_Animator.SetFloat("FaceY", 1);
                m_Sword_Animator.SetFloat("FaceX", 0); m_Sword_Animator.SetFloat("FaceY", 1);
            break;
            case (int) Direction.Left:
                m_Animator.SetFloat("FaceX", -1); m_Animator.SetFloat("FaceY", 0);
                m_Sword_Animator.SetFloat("FaceX", -1); m_Sword_Animator.SetFloat("FaceY", 0);
            break;
            default:
                m_Animator.SetFloat("FaceX", 0); m_Animator.SetFloat("FaceY", -1);
                m_Sword_Animator.SetFloat("FaceX", 0); m_Sword_Animator.SetFloat("FaceY", -1);
            break;
        }

        // Flip if facing right.
        if (direction == (int) Direction.Right) {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
}
