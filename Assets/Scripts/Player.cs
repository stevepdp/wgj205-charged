using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerHealth playerHealth;





    // player play state
    bool playerChargeState = true; // false means a negetive charge (also default), true is a positive charge
    [SerializeField]
    public int _playerChargeNo;
    public string directionFacing = "right";
    public bool isExiting = false;
    public bool isRunning = false;
    private bool _playerHasBox = false;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    // Player ground checks
    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    private bool _landingSoundCanPlay = false;

    // Player box detect checks
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    
    [SerializeField]
    private float _jumpForce = 0.01f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;

    

    private Animator _animator;
    private GameManager _gameManager;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;

    enum charge
    {
        neutral,  //0
        negative, //1
        positive  //2
    }

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        //transform.position = new Vector3(-1, 0, 0);

        SetPlayerDefaults();
    }

    void Update()
    {
        if (playerHealth.HP > 0 && !isExiting)
        {
            PlayerJump();
            BetterJump();
            PlayerInvertCharge();
            PlayerGrabStorageBox();
            CheckIfGrounded();

            // Update animation bools
            _animator.SetBool("Grounded", isGrounded);
            _animator.SetBool("Charge", playerChargeState);
            _animator.SetBool("Running", isRunning);
        }

        if (isExiting || playerHealth.HP == 0) {
            PlayerFreeze();
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
            if (_landingSoundCanPlay && _rigidBody.velocity.y <= 0 && SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("land");
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
        if (Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
        {
            playerChargeState = !playerChargeState;
            PlayerRejectStorageBox();
        }

        if (playerChargeState)
        {
            //mTextOverHead.text = "+";
            _playerChargeNo = (int) charge.positive;
        }
        else
        {
            //mTextOverHead.text = "-";
            _playerChargeNo = (int) charge.negative;
        }
    }

    private void PlayerGrabStorageBox() 
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            //Debug.Log("Found storage");
            if (grabCheck.collider.gameObject.GetComponent<StorageBox>().boxCharge != _playerChargeNo && !_playerHasBox)
            {
                // attraction - can pick up
                _playerHasBox = true;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
    }

    private void PlayerRejectStorageBox()
    {
        if (boxHolder.transform.childCount > 0)
        {
            //Debug.Log("Children found");
            Transform[] children = boxHolder.transform.GetComponentsInChildren<Transform>();

            int loopCount = 0;

            foreach (Transform child in children)
            {
                // first item in children will be the parent, so we have to skip the first iteration
                if (loopCount > 0)
                {
                    //Debug.Log(child.tag);
                    child.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    child.gameObject.GetComponent<Rigidbody2D>().simulated = true;
                    child.gameObject.GetComponent<StorageBox>().isDeadly = true;
                    // TODO: fix the awful .GetComponent uses here

                    if (directionFacing == "right")
                    {
                        //Debug.Log("Fire 1");
                        child.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(7.5f, 0), ForceMode2D.Impulse); // FIRE RIGHT
                    }
                    else
                    {
                        //Debug.Log("Fire 2");
                        child.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-7.5f, 0), ForceMode2D.Impulse); // FIRE LEFT
                    }
                }
                loopCount++;
            }

            boxHolder.transform.DetachChildren();
            _playerHasBox = false;
        }
        else
        {
            //Debug.Log("Box holder is empty");
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

    void PlayerJump()
    {
        if ((Input.GetButtonDown("Fire1") || (Input.GetButtonDown("Fire2")))
            && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("jump");
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            additionalJumps--;
            _landingSoundCanPlay = true;
        }
    }

    void PlayerFreeze()
    {
        _rigidBody.velocity = new Vector2(0, 0);
        _animator.SetBool("Running", false);
    }

    void SetPlayerDefaults()
    {
        PlayerInvertCharge();
    }
}
