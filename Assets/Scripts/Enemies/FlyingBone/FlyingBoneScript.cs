using UnityEngine;

public class FlyingBone : MonoBehaviour
{
    // Rigidbody
    private Rigidbody2D _rb = null;

    // Collider Settings
    private BoxCollider2D _boxCollider = null;

    // Direction Settings
    private float randomAngle = 0f;
    [SerializeField] private LayerMask playableMask;

    // Rotation Settings
    private float rotationSpeed = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        randomAngle = Random.Range(0f, 360f);
        rotationSpeed = Random.Range(15f, 25f);
        transform.Rotate(0, 0, Random.Range(0f, 360f));
    }

    void FixedUpdate()
    {
        float Radians = randomAngle * Mathf.Deg2Rad;
        Vector2 NewDirection = new Vector2(Mathf.Cos(Radians), Mathf.Sin(Radians));
        _rb.AddForce(NewDirection * 10f, ForceMode2D.Force);
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
