using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float climbSpeed;

    public bool canFly = false;

    [SerializeField] bool isGrounded = true;
    [SerializeField] bool isClimbing = false;

    [SerializeField] bool touchOneWayPlatform = false;

    private Robot robot;
    private Rigidbody2D rb;

    bool jump = false;

    float move;
    float climb;
    Vector3 groundCheck;    
    Vector3 ladderCheck;

    float groundCheckRadius;

    LayerMask platformMask;
    LayerMask vineMask;
    LayerMask oneWayPlatformMask;

    int playerLayer;
    int platformLayer;
    int oneWayPlatformLayer;

    void Start()
    {
        robot = GetComponent<Robot>();  
        rb = GetComponent<Rigidbody2D>();

        groundCheckRadius = 0.1f;

        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        oneWayPlatformLayer = LayerMask.NameToLayer("OneWayPlatform");

        platformMask = LayerMask.GetMask("Platform");
        vineMask = LayerMask.GetMask("Vine");
        oneWayPlatformMask = LayerMask.GetMask("OneWayPlatform");
    }

    void Update()
    {
        moveSpeed = robot.stats.Get(StatType.MoveSpeed);
        jumpPower = robot.stats.Get(StatType.JumpPower);
        climbSpeed = robot.stats.Get(StatType.ClimbSpeed);


        groundCheck = transform.position - new Vector3(0, transform.localScale.y / 2, 0);
        ////하드코딩!!!
        ladderCheck = transform.position - new Vector3(0, 0.4f, 0); 

        //좌우 이동 
        move = Input.GetAxis("Horizontal");
        //점프 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        //사다리 타기
        climb = Input.GetAxis("Vertical");

    }   
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck, groundCheckRadius, platformMask) != null 
                    || Physics2D.OverlapCircle(groundCheck, groundCheckRadius, oneWayPlatformMask) != null;
        touchOneWayPlatform = Physics2D.OverlapCircle(groundCheck, groundCheckRadius, oneWayPlatformMask) != null;

        ////하드코딩!!!
        isClimbing = Physics2D.OverlapBox(ladderCheck, new Vector2(0.5f, 0.1f), 0f, vineMask ) != null;   
        
        if(isClimbing)
        {
            rb.gravityScale = 0;
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true); //플레이어와 플랫폼 충돌 무시
        }
        else
        {
            rb.gravityScale = 1;
            Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, false); //플레이어와 플랫폼 충돌 무시
        }

        float moveAmount = move * moveSpeed;
        rb.linearVelocity = new Vector2(moveAmount, rb.linearVelocity.y);
        
        if(isClimbing)  
        {
            float climbAmount = climb * moveSpeed * climbSpeed;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbAmount);
        }
        if(jump && isGrounded && !isClimbing)
        {
            rb.AddForce(new Vector2(0, 1) * jumpPower, ForceMode2D.Impulse);
        }

        jump = false;

        //one-way platform
        if(isGrounded && rb.linearVelocity.y < 0 && touchOneWayPlatform)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, oneWayPlatformLayer, false);
        }
        if(!touchOneWayPlatform)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, oneWayPlatformLayer, true);
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("OneWayPlatform"))
        {
            touchOneWayPlatform = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck, groundCheckRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(ladderCheck, new Vector3(0.5f, 0.1f, 0));
    }
} 
