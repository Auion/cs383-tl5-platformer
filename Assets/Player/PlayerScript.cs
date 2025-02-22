using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // Input Settings
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.W;
    //[SerializeField] private KeyCode _down = KeyCode.S;

    // Movement Settings
    [SerializeField] private float _maxSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 10f;

    // Grounded settings
    private bool isGrounded;
    [SerializeField] private float groundCheckDistance = 0.6f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D _rb = null;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        PlayerMovement();
        IsGrounded();
    }

    void PlayerMovement(){
        // Left Right Movement
        if (Input.GetKey(_left)){
            _rb.linearVelocityX = -1 * _maxSpeed;
        }
        else if (Input.GetKey(_right)){
            _rb.linearVelocityX = _maxSpeed;
        }
        else{
            _rb.linearVelocityX = 0;
        }

        // Jumping
        if (Input.GetKey(_jump) && isGrounded){
            _rb.linearVelocityY = _jumpForce;
        }
    }

    void IsGrounded(){
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.green);
    }
}
