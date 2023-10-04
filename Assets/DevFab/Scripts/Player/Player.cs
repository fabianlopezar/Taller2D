/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
<summary>
Descripcion clase: Clase que representa al jugador y controla su movimiento, ataques y colisiones.
</summary>
*/
public class Player :Entity
{
    
    [Header("Move info")]
    /*
    <summary>
    Descripcion de atributos: Velocidad de movimiento del jugador.
    </summary>
    */
    [SerializeField] private float moveSpeed;
    /*
    <summary>
    Descripcion de atributos: Fuerza de salto del jugador.
    </summary>
    */
    [SerializeField] private float jumpForce;

    [Header("Dash info")]
    /*
    <summary>
    Descripcion de atributos: Velocidad de dash del jugador.
    </summary>
    */
    [SerializeField] private float dashSpeed;
    /*
    <summary>
    Descripcion de atributos: Duración del dash.
    </summary>
    */
    [SerializeField] private float dashDuration;
    /*
    <summary>
    Descripcion de atributos: Tiempo restante del dash.
    </summary>
    */
    private float dashTime;

    /*
    <summary>
    Descripcion de atributos: Tiempo de enfriamiento del dash.
    </summary>
    */
    [SerializeField] private float dashCooldown;
    /*
    <summary>
    Descripcion de atributos: Tiempo restante de enfriamiento del dash.
    </summary>
    */
    private float dashCooldownTimer;
    [Header("Attack info")]
    /*
    <summary>
    Descripcion de atributos: Duración de la ventana de tiempo para realizar combos de ataque.
    </summary>
    */
    [SerializeField]private float comboTime = 0.3f;
    /*
    <summary>
    Descripcion de atributos:Ventana de tiempo para realizar combos de ataque.
    </summary>
    */
    private float comboTimeWindow;
    /*
    <summary>
    Descripcion de atributos:  Estado de ataque del jugador.
    </summary>
    */
    private bool isAttacking;
    /*
    <summary>
    Descripcion de atributos: Contador de combos.
    </summary>
    */
    private int comboCounter;
    /*
    <summary>
    Descripcion de atributos: Entrada de teclado horizontal.
    </summary>
    */
    private float xInput;
    [Header("CheckPoint")]
    /*
    <summary>
    Descripcion de atributos:  Nombre del punto de control.
    </summary>
    */
    public string checkpointName;
    /*
    <summary>
    Descripcion de atributos: Prefabricado de la bala.
    </summary>
    */
    public GameObject balaPrefab;
    /*
    <summary>
    Descripcion de atributos: Punto de aparición de la bala.
    </summary>
    */
    public Transform spawnPointBala;

    [Header("Disparo")]
    /*
    <summary>
    Descripcion de atributos: Variable de prueba.
    </summary>
    */
    public float prueba;
    /*
    <summary>
    Descripcion de atributos: Dirección de disparo.
    </summary>
    */
    public Vector3 direction;
    /*
    <summary>
    Descripcion de atributos: Segunda dirección de disparo.
    </summary>
    */
    public Vector3 direction2;

    
    [Header("Sonidos")]
    /*
    <summary>
    Descripcion de atributos:  Sonidos para diferentes acciones del jugador.
    </summary>
    */
    public AudioClip jumpSound;
    /*
    <summary>
    Descripcion de atributos:  Sonidos para diferentes acciones del jugador.
    </summary>
    */
    public AudioClip shootSound;
    /*
    <summary>
    Descripcion de atributos:  Sonidos para diferentes acciones del jugador.
    </summary>
    */
    public AudioClip dashSound;
    /*
    <summary>
    Descripcion de atributos:  Sonidos para diferentes acciones del jugador.
    </summary>
    */
    public AudioClip damageSound;
    /*
    <summary>
    Descripcion de atributos:Referencia al componente AudioSource para reproducir sonidos.
    </summary>
    */
    private AudioSource audioSource;


/*
<summary>
Descripcion de metodo: Método de inicio que inicializa algunos atributos y obtiene una referencia al componente AudioSource.
</summary>
*/
    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }
    /*
<summary>
Descripcion de metodo: Método que se llama en cada fotograma para actualizar el comportamiento del jugador.
</summary>
*/
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
    /*
<summary>
Descripcion de metodo:  Método para realizar un dash.
</summary>
*/
    private void DashAbility()
    {
        if( dashCooldownTimer < 0 && !isAttacking) { 
        dashCooldownTimer = dashCooldown;
        dashTime = dashDuration;
        }
    }


    /*
   <summary>
   Descripcion de metodo: Método para comprobar las entradas del jugador (teclas presionadas).
   </summary>
   */
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
    /*
<summary>
Descripcion de metodo: Método para iniciar el evento de ataque.
</summary>
*/
    private void StartAttackEvent()
    {
        if (!isGrounded)
            return;
        /*if (comboTimeWindow < 0)
            comboCounter = 0;*/
        isAttacking = true;
        comboTimeWindow = comboTime;
    }
    /*
<summary>
Descripcion de metodo: Método para controlar el movimiento del jugador.
</summary>
*/
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
    /*
<summary>
Descripcion de metodo: Método para realizar un salto.
</summary>
*/
    private void Jump()
    {
        if (estaMuerto == false)
        {
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                audioSource.PlayOneShot(jumpSound);
        }
    }
    /*
<summary>
Descripcion de metodo:  Método para controlar los estados del Animator.
</summary>
*/
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
    /*
<summary>
Descripcion de metodo: Método para controlar la dirección del jugador.
</summary>
*/
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
    /*
<summary>
Descripcion de metodo: Método para controlar el final del ataque.
</summary>
*/
    public void AttackOver()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter > 2)
            comboCounter = 0;       
    }
    /*
<summary>
Descripcion de metodo:  Método que se activa cuando el jugador colisiona con otros objetos.
</summary>
*/
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
    /*
<summary>
Descripcion de metodo: Método para verificar si el jugador ha muerto.
</summary>
*/
    public void EstaMuerto()
    {
        if (currentHealth <= 0)
        {           
            estaMuerto = true;
            EventoMuerte();
            Debug.Log("g");
        }
    }
    /*
<summary>
Descripcion de metodo: Método para encontrar un punto de control por nombre.
</summary>
*/
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
    /*
<summary>
Descripcion de metodo:Método para manejar el evento de muerte del jugador.
</summary>
*/
    public void EventoMuerte()
    {
        Transform checkpoint = EncontrarCheckPoint(checkpointName);
        if (checkpoint != null)
        {
            StartCoroutine(TeleportAfterDelay(this.gameObject,3f,checkpoint));          
        }
        else
        {
            Debug.LogError("Player: No se encontró el punto de control con el nombre: " + checkpointName);
        }
       }
    /*
<summary>
Descripcion de metodo: Método para manejar un golpe al jugador.
</summary>
*/
    public void Hit()
    {
        currentHealth -= 10;
        audioSource.PlayOneShot(damageSound);
        EstaMuerto();        
    }
    /*
<summary>
Descripcion de metodo:  Método para disparar un proyectil desde el jugador.
</summary>
*/
    private void Shoot()
    {       
        GameObject bala = Instantiate(balaPrefab, transform.position+direction2, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
        audioSource.PlayOneShot(shootSound);
    }

}
