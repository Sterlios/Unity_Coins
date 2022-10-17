using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speed = 2;
    [SerializeField] private float _jumpForce;

    private const string IsRunName = "isRun";

    private Animator _animator;
    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private GroundChecker _groundCheck;
    private int _isRunHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundChecker>();
        _isRunHash = Animator.StringToHash(IsRunName);
    }

    private void Update()
    {
        Jump();
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundCheck.IsGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        float direction = Input.GetAxis("Horizontal");
        _animator.SetBool(_isRunHash, direction != 0);
        _sprite.flipX = direction < 0;
        transform.position += new Vector3(direction * _speed * Time.deltaTime, 0, 0);
    }
}
