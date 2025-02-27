using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerScript : MonoBehaviour
{

    // Input Settings
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.W;
    [SerializeField] private KeyCode _sleep = KeyCode.S;

    // Movement Settings
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    // Grounded & Roofed Settings
    private bool isGrounded;
    private bool isRoofed;
    private bool isRoofedStuck;
    [SerializeField] private float groundCheckDistance = 1f;
    [SerializeField] private float roofCheckDistance = 0.8f;
    [SerializeField] private LayerMask groundMask;

    // Rigidbody
    private Rigidbody2D _rb = null;

    // Sprite Animation
    [SerializeField] private Sprite walkSprite1;
    [SerializeField] private Sprite walkSprite2;
    [SerializeField] private Sprite sleepSprite;
    private SpriteRenderer _spriteRenderer = null;
    private float walkTimer = 0f;
    private float walkSwitchTime = 0.2f;

    // Collider Settings
    private BoxCollider2D _boxCollider = null;

    // Sleep Settings
    [SerializeField] private float _energy_max = 60000f;
    [SerializeField] private float _energy = 60000f;

    // Health 9 lives!
    private float health = 9f;

    // Sound
    private AudioSource _audioSource;
    [SerializeField] private AudioClip hurt;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip walk;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerMovement();
        IsGrounded();
        IsRoofed();
        Warp();
        EnergyDrain();
        EnergyRestore();
    }

    void PlayerMovement()
    {
        // Left Right Movement
        if (_spriteRenderer.sprite != sleepSprite)
        {
            if (Input.GetKey(_left))
            {
                _rb.linearVelocityX = -1 * _maxSpeed;
                _spriteRenderer.flipX = true;
                _energy -= 1000f * Time.deltaTime;
                AnimateWalking();
            }
            else if (Input.GetKey(_right))
            {
                _rb.linearVelocityX = _maxSpeed;
                _spriteRenderer.flipX = false;
                _energy -= 1000f * Time.deltaTime;
                AnimateWalking();
            }
            else
            {
                _rb.linearVelocityX = 0;
            }

            // Jumping
            if (Input.GetKeyDown(_jump) && isGrounded)
            {
                _rb.linearVelocityY = _jumpForce;
                _energy -= 1500f * Time.deltaTime;
                _audioSource.PlayOneShot(jump);
            }

            // Roof Sticking
            if (Input.GetKey(_jump) && isRoofed)
            {
                _spriteRenderer.flipY = true;
                _rb.gravityScale = 0f;
                isRoofedStuck = true;
            }
            else
            {
                _rb.gravityScale = 1f;
                _spriteRenderer.flipY = false;
                isRoofedStuck = false;
            }

            // Sleeping
            if (Input.GetKey(_sleep) && _energy < _energy_max)
            {
                _spriteRenderer.sprite = sleepSprite;
                _spriteRenderer.flipY = false;
                _rb.gravityScale = 1f;
                UpdateCollider();
            }
        }
    }

    void IsGrounded()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.green);
    }

    void AnimateWalking()
    {
        walkTimer += Time.deltaTime;

        if (walkTimer >= walkSwitchTime && (isGrounded || isRoofedStuck) == true)
        {
            if (_spriteRenderer.sprite == walkSprite1)
            {
                _spriteRenderer.sprite = walkSprite2;
            }
            else
            {
                _spriteRenderer.sprite = walkSprite1;
            }
            walkTimer = 0f;
            _audioSource.PlayOneShot(walk);
        }
    }

    void Warp()
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

    void UpdateCollider()
    {
        if (_spriteRenderer.sprite == sleepSprite)
        {
            _boxCollider.offset = new Vector2(0.005093455f, -0.0769642f);
            _boxCollider.size = new Vector2(1.548643f, 0.5766324f);
        }
        else
        {
            _boxCollider.offset = new Vector2(0.07920766f, -0.03284857f);
            _boxCollider.size = new Vector2(1.541585f, 1.053081f);
        }
    }

    void EnergyDrain()
    {
        if (_spriteRenderer.sprite != sleepSprite)
        {
            _energy -= 10000f * Time.deltaTime;
        }
        if (_energy <= 0)
        {
            _energy = 0;
            _spriteRenderer.sprite = sleepSprite;
            _spriteRenderer.flipY = false;
            _rb.gravityScale = 1f;
            UpdateCollider();
        }
    }

    void EnergyRestore()
{  
        if (_energy < _energy_max && _spriteRenderer.sprite == sleepSprite)
        {
            _energy += 20000f * Time.deltaTime;
            if (_energy >= _energy_max)
            {
                _energy = _energy_max;
                _spriteRenderer.sprite = walkSprite1;
                if (isGrounded == true)
                {
                    _rb.linearVelocityY = 2f;
                }
                UpdateCollider();
            }
        }
    }

    void IsRoofed()
    {
        isRoofed = Physics2D.Raycast(transform.position, Vector2.up, roofCheckDistance, groundMask);
        Debug.DrawRay(transform.position, Vector2.up * roofCheckDistance, Color.red);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Death();
        }
        _audioSource.PlayOneShot(hurt);
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
