using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _hp = 1;

    // player play state
    private bool _playerChargeState = false; // false means a negetive charge (also default), true is a positive charge
    private bool _playerIsDead = false;
    private bool _playerRunState = false;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    // Player ground checks
    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    private bool _landingSoundCanPlay = false;

    [SerializeField]
    private float _moveSpeed = 2f;
    [SerializeField]
    private float _jumpForce = 0.01f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;

    private float horizontalInput;
    private float verticalInput;

    private Animator _animator;
    private GameManager _gameManager;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;

    // floater text
    [SerializeField]
    Text mTextOverHead;
    Transform mTransform;
    Transform mTextOverTransform;
    private float _textDistFromPlayer = 52; // player is 28x24. font height is 24. So 28+24 = 44                                            

    private void Awake()
    {
        mTransform = transform;
        mTextOverTransform = mTextOverHead.transform;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //transform.position = new Vector3(-1, 0, 0);

        SetPlayerDefaults();
    }

    void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        // add a tiny bit of height?
        screenPos.y += _textDistFromPlayer;
        mTextOverTransform.position = screenPos;
    }


    void Update()
    {
        if (!_playerIsDead)
        {
            PlayerMove();
            PlayerJump();
            BetterJump();
            PlayerInvertCharge();
        }
        CheckIfGrounded();

        // Update animation bools
        _animator.SetBool("Grounded", isGrounded);
        _animator.SetBool("Charge", _playerChargeState);
        _animator.SetBool("Running", _playerRunState);
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
            if (_landingSoundCanPlay && _rigidBody.velocity.y <= 0) SoundManager.PlaySound("land");
            additionalJumps = defaultAdditionalJumps;
            _landingSoundCanPlay = false;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
            _landingSoundCanPlay = true;
        }
    }

    void PlayerInvertCharge()
    {
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
        {
            _playerChargeState = !_playerChargeState;
        }

        if (_playerChargeState)
        {
            mTextOverHead.text = "+";
        }
        else
        {
            mTextOverHead.text = "-";
        }
    }

    void BetterJump()
    {
        if (_rigidBody.velocity.y < 0)
        {
            _rigidBody.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rigidBody.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void OnPlayerDead()
    {
        _playerIsDead = true;
        _animator.SetTrigger("Dead");
        Debug.Log("Player deaded.");
    }

    void PlayerJump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            SoundManager.PlaySound("jump");
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            additionalJumps--;
            _landingSoundCanPlay = true;
        }
    }

    void PlayerMove()
    {
        // flip player sprite according to facing direction
        if (horizontalInput < 0) _spriteRenderer.flipX = true;
        if (horizontalInput > 0) _spriteRenderer.flipX = false;

        if (horizontalInput != 0)
        {
            _playerRunState = true;
        }
        else
        {
            _playerRunState = false;
        }

        // handle left/right movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        float moveBy = horizontalInput * _moveSpeed;
        _rigidBody.velocity = new Vector2(moveBy, _rigidBody.velocity.y); 
    }

    void SetPlayerDefaults()
    {
        
    }
}
