using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D _rb;

    // Speed
    private float acceleration = 15f;
    private float topSpeed = 17f;
    private float _jumpForce = 20f;

    // Stuck
    private float stuck = 0f;

    // Grounded & Roofed Settings
    private bool isGrounded;
    [SerializeField] private float groundCheckDistance = 1f;
    [SerializeField] private LayerMask groundMask;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Warp();
        IsGrounded();
        Movement();
    }

    private void Movement()
    {
        if (target != null)
        {
            if (transform.position.x < target.position.x)
            {
                _rb.linearVelocityX += acceleration * Time.deltaTime;
            }
            else
            {
                _rb.linearVelocityX -= acceleration * Time.deltaTime;
            }
            _rb.linearVelocityX = Mathf.Clamp(_rb.linearVelocityX, -topSpeed, topSpeed);
        }

        /* flip left or right depending on direction */
        if (_rb.linearVelocityX > 0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        var directionTowardsTarget = (target.position - this.transform.position).normalized;
        float angleRadians = Mathf.Atan2(directionTowardsTarget.y, directionTowardsTarget.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        if (angleDegrees > 25 && angleDegrees < 155 && isGrounded == true)
        {
            _rb.linearVelocityY = _jumpForce;
        }

        if ((angleDegrees > 50 && angleDegrees < 130) || (angleDegrees < -50 && angleDegrees > -130))
        {
            stuck += 1 * Time.deltaTime;
            if (stuck > 1.5f)
            {
                _rb.linearVelocityX *= 20f;
            }
        } else
        {
            stuck = 0;
        }
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.green);
    }

    private void Warp()
    {
        if (transform.position.x > 10.2)
        {
            transform.position = new Vector3(-10.1f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -10.2)
        {
            transform.position = new Vector3(10.1f, transform.position.y, transform.position.z);
        }
    }

}