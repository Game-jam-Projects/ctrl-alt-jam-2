using UnityEngine;

[RequireComponent(typeof(InputReference))]
public class PlayerController : MonoBehaviour
{
    public bool isDebug;
    [Header("Player Status")]
    [SerializeField] private Animator animator;

    private SpriteRenderer _playerSprite;
    private Collider2D _playerCollider;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float oxygenSpeed = 2.5f;
    [SerializeField] private float jumpForce = 124f;
    public bool isInteraction = false;

    public bool isPressedPuzzle;
    public bool isPuzzleStart;

    public GameObject puzzleCurrent;
    [SerializeField] private bool isLookingLeft;

    [Header("Ground")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;
    private bool isJumping;
    [SerializeField] private GameObject groundCheck;

    [Header("SizeGizmo")]
    [SerializeField] private float groundXSize;
    [SerializeField] private float groundYSize;

    [Header("Slopes")]
    [SerializeField] private float slopesValidadeDistance = 0.4f;
    [SerializeField] private bool isOnSlope;

    [Header("PhysicsMaterial2D")]
    [SerializeField] private PhysicsMaterial2D noFrictionMaterial;
    [SerializeField] private PhysicsMaterial2D frictionMaterial;



    [SerializeField] private bool isLookLeft = false;

    private InputReference _inputReference;

    private Rigidbody2D _rigidbody2D;
    private IDamageable health;

    private Vector2 perpendicularSpeed;
    private float slopeAngle;


    private bool blockPlayerInputs;
    private bool isStartedCilinder;

    private float starterGravityScale;

    private float _currentSpeed;

    public bool isfinalParte;

    [Header("Footstep")]
    public bool isWalkWarning;

    private bool FmodParameter = false;
    private bool FmodFalling = false;

    private void Awake()
    {
        _inputReference = GetComponent<InputReference>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _playerCollider = GetComponent<Collider2D>();
        health = GetComponent<IDamageable>();

        starterGravityScale = _rigidbody2D.gravityScale;
    }


    private void Update()
    {
        animator.SetFloat("speedY", _rigidbody2D.velocity.y);

        DetectSlopes();

        if (health.IsDie)
            return;

      

        if (blockPlayerInputs)
            return;

        if (_inputReference.PauseButton.IsPressed && CanvasController.Instance.painelDisabled == null )
        {
            Debug.Log("Pause");
            GameManager.Instance.PauseResume();
        }


        if (GameManager.Instance && GameManager.Instance.Paused)
            return;

        if (isGrounded && isJumping)
        {
            CANCELJUMP();
        }

        if (_inputReference.JumpButton.IsPressed && isGrounded && !isJumping)
        {
            JUMP();
        }

        if (_inputReference.JumpButton.IsPressed == false && isGrounded == false)
        {

        }

        if (isJumping)
            return;

        if (isDebug)
            Debug.LogFormat($"Interect.IsPressed: {_inputReference.interacaoButton.IsPressed} // IsInteraction: {isInteraction} " +
                $"// !IsPressedPuzzle: {isPressedPuzzle} // !isfinalParte: {isfinalParte}");
        if (_inputReference.interacaoButton.IsPressed && isInteraction && !isPressedPuzzle && !isfinalParte)
        {
            isPressedPuzzle = true;
          
        }

        if (_inputReference.interacaoButton.IsPressed && isInteraction && isfinalParte)
        {
            isPressedPuzzle = true;
           
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.transform.position, new Vector2(groundXSize, groundYSize), 0f, whatIsGround);
        OnMovimentPlayer();

        if (blockPlayerInputs)
            return;


        if (health.IsDie)
            return;


        if (_rigidbody2D.velocity != new Vector2(0, 0))
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        //virar o player
        if (_inputReference.Movement.x < 0 && isLookLeft == false)
        {
            Flip();
        }
        else if (_inputReference.Movement.x > 0 && isLookLeft == true)
        {

            Flip();
        }

        animator.SetBool("isGrounded", isGrounded);
        if(isGrounded == false)
        {
            FmodFalling = true;
        }
        if (FmodFalling == true && isGrounded == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Foley/Fall", GetComponent<Transform>().position);
            FmodFalling = false;
        }
    }

    public void ResetWalk()
    {
        animator.SetBool("isWalk", false);
    }

   

  

  

    private void OnMovimentPlayer()
    {
        //if (isOnSlope)
        //{
        //    if (isJumping)
        //    {
        //        isOnSlope = false;
        //    }
        //    else
        //    {
        //        //Movimentacao SLOP
        //        _rigidbody2D.velocity = new Vector2(-_inputReference.Movement.x * _currentSpeed * perpendicularSpeed.x,
        //            -_inputReference.Movement.x * _currentSpeed * perpendicularSpeed.y);

        //    }
        //}
        //else
        //{
            //Movimentacao Padrao
            _rigidbody2D.velocity = new Vector2(_inputReference.Movement.x * _currentSpeed, _rigidbody2D.velocity.y);

//        }
    }
    public void DetectSlopes()
    {
        RaycastHit2D hitSlope = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, slopesValidadeDistance, whatIsGround);

        if (hitSlope)
        {
            perpendicularSpeed = Vector2.Perpendicular(hitSlope.normal).normalized;
            slopeAngle = Vector2.Angle(hitSlope.normal, Vector2.up);
            isOnSlope = slopeAngle != 0;
        }
        else
        {
            isOnSlope = false;
        }

        if (isOnSlope && _inputReference.Movement.x == 0)
        {
            _rigidbody2D.sharedMaterial = frictionMaterial;
        }
        else
        {
            _rigidbody2D.sharedMaterial = noFrictionMaterial;
        }
    }
    public void Flip()
    {
        if (health.IsDie == false)
        {
            isLookLeft = !isLookLeft;
            float x = transform.localScale.x * -1; //Inverte o sinal do scale X
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }

    }
    public void JUMP()
    {
        if (isGrounded == true)
        {
            isJumping = true;
            isGrounded = false;
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void CANCELJUMP()
    {
        isJumping = false;
    }

    public void OnDelayJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(groundCheck.transform.position, new Vector2(groundXSize, groundYSize));

        Gizmos.DrawRay(transform.position, Vector2.down * slopesValidadeDistance);

    }

    public void ActivePlayer()
    {
        _playerCollider.enabled = true;
        _playerSprite.enabled = true;
        _rigidbody2D.gravityScale = starterGravityScale;
        blockPlayerInputs = false;
    }

    public void DisablePlayerWithoutSprite()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.gravityScale = 0;
        ResetWalk();
        _playerCollider.enabled = false;
        //_playerSprite.enabled = false;
        blockPlayerInputs = true;
    }

    public void DisablePlayer()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.gravityScale = 0;
        ResetWalk();
        _playerCollider.enabled = false;
        _playerSprite.enabled = false;
        blockPlayerInputs = true;
    }
}
