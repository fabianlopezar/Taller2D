/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andr�s Garz�n Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicol�s Ram�rez Arango 2195824
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player :Entity
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
    [Header("CheckPoint")]
    public string checkpointName;

    public GameObject balaPrefab;
    public Transform spawnPointBala;

    [Header("Disparo")]
    public float prueba;
    public Vector3 direction;
    public Vector3 direction2;
    
    [Header("Sonidos")]
    public AudioClip jumpSound;
    public AudioClip shootSound;
    public AudioClip dashSound; 
    public AudioClip damageSound; 
    private AudioSource audioSource;



    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
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
          Shoot();
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
        if (estaMuerto == false) { 
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
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Jump()
    {
        if (estaMuerto == false)
        {
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                audioSource.PlayOneShot(jumpSound);
        }
    }

    public void AnimatorControllers()
    {
      bool  isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDashing", dashTime > 0);

        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);
        anim.SetBool("IsDeath", estaMuerto);
    }
   
    private void FlipController()
    {
    if(rb.velocity.x>0 && !facingRight)
        {
            direction = new Vector3(1, 0.0f, 0.0f);
            direction2 = new Vector3(prueba, 0.0f, 0.0f);
        
            Flip();
        }else if(rb.velocity.x<0 && facingRight)
        {
            direction = new Vector3(-1, 0.0f, 0.0f);
            direction2 = new Vector3(-prueba, 0.0f, 0.0f);
            
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
        if (other.CompareTag("Win"))
        {
           string nameScene = "Fin";
            chronometer.Instance.DetenerCronometro();
           SceneManager.LoadScene(nameScene);        
        }
        if (other.CompareTag("Agua")){
            Transform checkpoint = EncontrarCheckPoint(checkpointName);
            this.gameObject.transform.position = checkpoint.position;
        }
    }
    public void EstaMuerto()
    {
        if (currentHealth <= 0)
        {           
            estaMuerto = true;
            EventoMuerte();
            Debug.Log("g");
        }
    }

    public Transform EncontrarCheckPoint(string name)
    {
        GameObject checkpointEncontrado = GameObject.Find(name);
        if (checkpointEncontrado != null)
        {
            return checkpointEncontrado.transform;
        }
        return null;
    }
    IEnumerator TeleportAfterDelay(GameObject player,float delay, Transform targetCheckPoint)
    {

        yield return new WaitForSeconds(delay);

  
        player.transform.position = targetCheckPoint.position;
        estaMuerto = false;
        currentHealth = 100;

    }
    public void EventoMuerte()
    {
        Transform checkpoint = EncontrarCheckPoint(checkpointName);
        if (checkpoint != null)
        {
            StartCoroutine(TeleportAfterDelay(this.gameObject,3f,checkpoint));          
        }
        else
        {
            Debug.LogError("Player: No se encontr� el punto de control con el nombre: " + checkpointName);
        }
       }
    public void Hit()
    {
        currentHealth -= 10;
        audioSource.PlayOneShot(damageSound);
        EstaMuerto();        
    }
    private void Shoot()
    {       
        GameObject bala = Instantiate(balaPrefab, transform.position+direction2, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
        audioSource.PlayOneShot(shootSound);
    }

}
