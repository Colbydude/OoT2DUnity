using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Direction {
        Right = 0,
        Up = 90,
        Left = 180,
        Down = 270
    }

    public int direction = (int) Direction.Down;
    public float speed = 8f;

    private Vector2 change;
    private bool moving;

    private Animator _animator;
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        int holdL, holdR, holdU, holdD;
        Vector2 change = Vector2.zero;

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

        // Move link.
        change = new Vector2(holdR - holdL, holdU - holdD);

        if (change != Vector2.zero) {
            _rigidBody.MovePosition(
                _rigidBody.position + change * speed * Time.deltaTime
            );
        }

        // Determine if moving and set direction.
        switch (holdL + holdR + holdU + holdD) {
            // Not moving.
            case 0:
                moving = false;
            break;
            // Moving.
            case 1:
                moving = true;
                direction = ((int) Direction.Left) * holdL + ((int) Direction.Up) * holdU + ((int) Direction.Down) * holdD;
            break;
            default:
                moving = true;

                switch (direction) {
                    case (int) Direction.Left:  if (holdR == 1) { direction = (int) Direction.Right; }  break;
                    case (int) Direction.Right: if (holdL == 1) { direction = (int) Direction.Left; }   break;
                    case (int) Direction.Up:    if (holdD == 1) { direction = (int) Direction.Down; }   break;
                    default:                    if (holdU == 1) { direction = (int) Direction.Up; }     break;
                }
            break;
        }
    }

    private void Animate()
    {
        if (moving) {
            _animator.Play("Walk");
        } else {
            _animator.Play("Idle");
        }

        // Set animation facing.
        switch (direction) {
            case (int) Direction.Right: _animator.SetFloat("FaceX", 1); _animator.SetFloat("FaceY", 0);     break;
            case (int) Direction.Up:    _animator.SetFloat("FaceX", 0); _animator.SetFloat("FaceY", 1);     break;
            case (int) Direction.Left:  _animator.SetFloat("FaceX", -1); _animator.SetFloat("FaceY", 0);    break;
            default:                    _animator.SetFloat("FaceX", 0); _animator.SetFloat("FaceY", -1);    break;
        }

        // Flip if facing right.
        if (direction == (int) Direction.Right) {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        } else {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
}
