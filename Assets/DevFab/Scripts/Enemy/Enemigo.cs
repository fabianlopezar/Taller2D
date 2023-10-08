/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
/*
    <summary>
        descripcion de la clase:El código define un enemigo que sigue al jugador, dispara balas cuando está cerca y controla sus animaciones de ataque, además de gestionar su salud y eliminación en caso de quedarse sin ella.
    </summary>
*/
using UnityEngine;

public class Enemigo : Health
{   /*<summary>
     * Descripcion del atributo: Se utiliza para rastrear la posición del jugador y determinar si el enemigo debe atacar.
     </summary>
     */
    public Transform player;
    /*<summary>
     * Descripcion del atributo: Este atributo público permite asignar un prefab de bala que el enemigo disparará cuando ataque al jugador.
     </summary>
     */
    public GameObject balaPrefab;
    /*<summary>
     * Descripcion del atributo: Se utiliza para controlar la frecuencia de disparo del enemigo.
     </summary>
     */
    private float LastShoot;
    /*<summary>
     * Descripcion del atributo: Se utiliza para controlar las animaciones del enemigo, como la animación de ataque.
     </summary>
     */
    public Animator anim;
    /*<summary>
     * Descripcion del atributo: Se utiliza para activar la animación de ataque y controlar el comportamiento de disparo.
     </summary>
     */
    public bool atacando;


    public void Awake()
    {
        anim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();
        AnimatorControllers();
        if (player == null) return;
        Flip();
        Attack();

    }

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

    private void Flip()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.1380816f, 0.1380816f, 0.1380816f);
        else transform.localScale = new Vector3(-0.1380816f, 0.1380816f, 0.1380816f);
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bala = Instantiate(balaPrefab, transform.position + direction * 2, Quaternion.identity);
        bala.GetComponent<BalaScript>().SetDirection(direction);
    }
    public void Hit()
    {
        currentHealth -= 10;
        if (currentHealth == 0) {
            GameManager.Instance.AddScore();
            Destroy(gameObject); 
        }
    }
    public void AnimatorControllers()
    {
        anim.SetBool("atacando", atacando);
    }
}
