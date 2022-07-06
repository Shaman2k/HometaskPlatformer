using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayerMask;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider2D;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private string _animationRunParameterName = "Speed";
    private string _animationJumpParametrName = "Jump";
    private float _animationRunSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger(_animationJumpParametrName);
    }

    private bool IsGrounded()
    {
        float extraHeightTest = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size - new Vector3(extraHeightTest, 0f, 0f), 0f, Vector2.down, extraHeightTest, _groundLayerMask);
        Color rayColor;

        if (raycastHit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        return raycastHit.collider != null;
    }

    private void Move()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (_direction != Vector2.zero)
        {
            _animationRunSpeed = 1f;
            _renderer.flipX = _direction.x > 0 ? false : true;
        }
        else
        {
            _animationRunSpeed = 0;
        }

        transform.Translate(_direction * _speed * Time.deltaTime);
        _animator.SetFloat(_animationRunParameterName, _animationRunSpeed);
    }
}
