/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andr�s Garz�n Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicol�s Ram�rez Arango 2195824
 */
/*
    <summary>
        descripcion de la clase:El c�digo define un enemigo que sigue al jugador, dispara balas cuando est� cerca y controla sus animaciones de ataque, adem�s de gestionar su salud y eliminaci�n en caso de quedarse sin ella.
    </summary>
*/
using UnityEngine;

public class Enemigo : Health
{   /*<summary>
     * Descripcion del atributo: Se utiliza para rastrear la posici�n del jugador y determinar si el enemigo debe atacar.
     </summary>
     */
    public Transform player;
    /*<summary>
     * Descripcion del atributo: Este atributo p�blico permite asignar un prefab de bala que el enemigo disparar� cuando ataque al jugador.
     </summary>
     */
    public GameObject balaPrefab;
    /*<summary>
     * Descripcion del atributo: Se utiliza para controlar la frecuencia de disparo del enemigo.
     </summary>
     */
    private float LastShoot;
    /*<summary>
     * Descripcion del atributo: Se utiliza para controlar las animaciones del enemigo, como la animaci�n de ataque.
     </summary>
     */
    public Animator anim;
    /*<summary>
     * Descripcion del atributo: Se utiliza para activar la animaci�n de ataque y controlar el comportamiento de disparo.
     </summary>
     */
    public bool atacando;

    /*<summary>
    * Descripcion del metodo: Inicializa la variable "anim" al obtener el componente Animator.
    </summary>
    */
    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    /*<summary>
   * Descripcion del metodo: Actualiza el comportamiento del enemigo, incluyendo la gesti�n de animaciones y el ataque al jugador.
   </summary>
   */
    protected override void Update()
    {
        base.Update();
        AnimatorControllers();
        if (player == null) return;
        Flip();
        Attack();

    }
    /*<summary>
   * Descripcion del metodo: Controla el comportamiento de ataque del enemigo, verificando la distancia al jugador y gestionando los disparos.
   </summary>
   */
    private void Attack()
    {
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            atacando = true;
            Shoot();
            LastShoot = Time.time;
        }
      if(distance>1.0f)
        {
            atacando = false;
        }
    }
    /*<summary>
  * Descripcion del metodo:  Voltea la escala del enemigo seg�n su direcci�n con respecto al jugador.
  </summary>
  */
    private void Flip()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.1380816f, 0.1380816f, 0.1380816f);
        else transform.localScale = new Vector3(-0.1380816f, 0.1380816f, 0.1380816f);
    }
    /*<summary>
 * Descripcion del metodo:   /*<summary>
  * Descripcion del metodo:  Dispara una bala en la direcci�n adecuada.
  </summary>
  */
 </summary>
 */
    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bala = Instantiate(balaPrefab, transform.position + direction * 2, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }
    /*<summary>
 * Descripcion del metodo:   /*<summary>
  * Descripcion del metodo: Reduce la salud del enemigo en 10 puntos y, si llega a cero, agrega puntos al marcador del juego y destruye al enemigo.
  </summary>
  */
    public void Hit()
    {
        currentHealth -= 10;
        if (currentHealth == 0) {
            GameManager.Instance.AddScore();
            Destroy(gameObject); 
        }
    }
    /*<summary>
 * Descripcion del metodo:   /*<summary>
  * Descripcion del metodo: Activa la animaci�n de ataque o la desactiva seg�n el valor de la variable "atacando".
  </summary>
  */
    public void AnimatorControllers()
    {
        anim.SetBool("atacando", atacando);
    }
}
