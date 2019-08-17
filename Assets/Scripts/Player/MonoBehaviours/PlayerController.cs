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

    protected SpriteRenderer m_Shadow_SpriteRenderer;
    protected Transform m_Shadow_Transform;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        m_Shadow_Transform = transform.Find("Shadow");
        m_Shadow_SpriteRenderer = m_Shadow_Transform.GetComponent<SpriteRenderer>();

    }

    void Start()
    {
        SceneLinkedSMB<PlayerController>.Initialise(m_Animator, this);
    }

    void Update()
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
    public void CheckForRoll()
    {
        if (m_Moving && Input.GetButtonDown("Action")) {
            m_Animator.Play("Roll");
        }
    }

    public Vector2 GetMoveVector()
    {
        return m_MoveVector;
    }

    public Transform GetShadowTransform()
    {
        return m_Shadow_Transform;
    }

    public SpriteRenderer GetShadowSpriteRenderer()
    {
        return m_Shadow_SpriteRenderer;
    }

    public void Movement()
    {
        int holdL, holdR, holdU, holdD;
        float speed;
        m_MoveVector = Vector2.zero;

        // Get actual key/joystick/button presses for each direction.
        holdL = Input.GetAxis("Horizontal") <= -0.5 ? 1 : 0;
        holdR = Input.GetAxis("Horizontal") >= 0.5 ? 1 : 0;
        holdU = Input.GetAxis("Vertical") >= 0.5 ? 1 : 0;
        holdD = Input.GetAxis("Vertical") <= -0.5 ? 1 : 0;

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

    public void SetHorizontalMovement(float newHorizontalMovement)
    {
        m_MoveVector.x = newHorizontalMovement;
    }

    public void SetMoveVector(Vector2 newMoveVector)
    {
        m_MoveVector = newMoveVector;
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
            case (int) Direction.Right: m_Animator.SetFloat("FaceX", 1); m_Animator.SetFloat("FaceY", 0);   break;
            case (int) Direction.Up:    m_Animator.SetFloat("FaceX", 0); m_Animator.SetFloat("FaceY", 1);   break;
            case (int) Direction.Left:  m_Animator.SetFloat("FaceX", -1); m_Animator.SetFloat("FaceY", 0);  break;
            default:                    m_Animator.SetFloat("FaceX", 0); m_Animator.SetFloat("FaceY", -1);  break;
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
