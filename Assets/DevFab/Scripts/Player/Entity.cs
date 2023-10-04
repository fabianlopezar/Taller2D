/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;

/*
<summary>
Descripcion clase:
</summary>
*/
public class Entity : Health
{
/*
<summary>
descripcion atributos:
</summary>
*/
    protected Rigidbody2D rb;
/*
<summary>
descripcion atributos:
</summary>
*/
    protected Animator anim;

    protected int facingDir = 1;
/*
<summary>
descripcion atributos:
</summary>
*/
    protected bool facingRight = true;

    [Header("Collision info")]/*
<summary>
descripcion atributos:
</summary>
*/
    [SerializeField] protected Transform groundCheck;
/*
<summary>
descripcion atributos:
</summary>
*/
    [SerializeField] protected float groundCheckDistance;
/*
<summary>
descripcion atributos:
</summary>
*/
    [SerializeField] protected LayerMask whatIsGround;
/*
<summary>
descripcion atributos:
</summary>
*/
    protected bool isGrounded;

    protected virtual void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CollisionChecks();
    }
    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }
    protected virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
}
