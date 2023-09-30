using UnityEngine;

public class Player : Health
{
    
    [Header("Move info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    private float dashTime;
    
    
    [SerializeField] private float dashCooldown;
    private float dashCooldownTimer;
    [Header("Attack info")]
    [SerializeField]private float comboTime = 0.3f;
    private float comboTimeWindow;
    private bool isAttacking;
    private int comboCounter;

    private float xInput;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        Movement();
        CheckInput();

        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeWindow -= Time.deltaTime;
      
 

        FlipController();
        AnimatorControllers();
    }

    private void DashAbility()
    {
        if( dashCooldownTimer < 0 && !isAttacking) { 
        dashCooldownTimer = dashCooldown;
        dashTime = dashDuration;
        }
    }

   

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartAttackEvent();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void StartAttackEvent()
    {
        if (!isGrounded)
            return;
        /*if (comboTimeWindow < 0)
            comboCounter = 0;*/
        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    private void Movement()
    {
        if (isAttacking)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else if (dashTime > 0)
        {
            rb.velocity = new Vector2(facingDir*dashSpeed,0);
        }
        else
        {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if(isGrounded)
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void AnimatorControllers()
    {
      bool  isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDashing", dashTime > 0);

        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
    }
   
    private void FlipController()
    {
if(rb.velocity.x>0 && !facingRight)
        {
            Flip();
        }else if(rb.velocity.x<0 && facingRight)
        {
            Flip();
        }
    }
   
    public void AttackOver()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter > 2)
            comboCounter = 0;       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Corazon"))
        {
            currentHealth += 10;
            Destroy(other.gameObject);
        }
    }
    public void EstaMuerto()
    {
        //Activar animacion muerto
        if (currentHealth <= 0)
        {
            anim.SetBool("isGrounded", true);
        }
        
        
    }
}
