/* Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;

/*
<summary>
Descripcion clase:Clase que hereda de Health y representa una entidad en el juego.
Contiene atributos y métodos relacionados con físicas, animaciones y detección de colisiones.
</summary>
*/
public class Entity : Health
{
    /*
    <summary>
    descripcion atributos:Almacena una referencia a un componente Rigidbody2D para el movimiento físico de la entidad.
    </summary>
    */
    protected Rigidbody2D rb;
    /*
    <summary>
    descripcion atributos:Almacena una referencia a un componente Animator para controlar animaciones.
    </summary>
    */
    protected Animator anim;

    protected int facingDir = 1;
    /*
    <summary>
    descripcion atributos: Booleano que indica si la entidad está mirando hacia la derecha.
    </summary>
    */
    protected bool facingRight = true;

    [Header("Collision info")]/*
<summary>
descripcion atributos:Transform que define la posición de detección de colisión con el suelo.
</summary>
*/
    [SerializeField] protected Transform groundCheck;
    /*
    <summary>
    descripcion atributos: Distancia de detección de colisión con el suelo.
    </summary>
    */
    [SerializeField] protected float groundCheckDistance;
    /*
    <summary>
    descripcion atributos:Máscara de capas para la detección de colisión con el suelo.
    </summary>
    */
    [SerializeField] protected LayerMask whatIsGround;
    /*
    <summary>
    descripcion atributos:Booleano que indica si la entidad está en contacto con el suelo.
    </summary>
    */
    protected bool isGrounded;
    /*
    <summary>
    descripcion del metodo:Inicializa las referencias al Rigidbody2D y al Animator en el inicio.
    </summary>
    */
    protected virtual void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    /*
    <summary>
    descripcion del metodo:Realiza comprobaciones de colisión en cada fotograma.
    </summary>
    */
    protected override void Update()
    {
        base.Update();
        CollisionChecks();
    }
    /*
    <summary>
    descripcion del metodo:Realiza la detección de colisión con el suelo utilizando un raycast.
    </summary>
    */
    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    /*
    <summary>
    descripcion del metodo:Voltea la entidad en la dirección opuesta.
    </summary>
    */
    protected virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    /*
    <summary>
    descripcion del metodo: Dibuja un rayo en el editor para visualizar la detección de colisión con el suelo.
    </summary>
    */
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
}
