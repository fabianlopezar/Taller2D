/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andr�s Garz�n Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicol�s Ram�rez Arango 2195824
 */
/*
    <summary>
        descripcion de la clase: Este c�digo representa un script de Unity llamado "BalaScript" que controla el 
        comportamiento de una bala en un juego. La bala tiene una velocidad, puede reproducir un sonido al ser disparada, 
        se destruir� despu�s de 2 segundos y puede detectar colisiones con enemigos y jugadores para infligir da�o y luego destruirse.
    </summary>
*/
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    /*<summary>
     * Descripcion del atributo: Esta variable p�blica define la velocidad de la bala.
     </summary>
     */
    public float Speed;
    /*<summary>
    * Descripcion del atributo:  Esta variable p�blica permite asignar un clip de sonido que se reproducir� cuando la bala sea disparada.
    </summary>
    */
    public AudioClip Sound;
    /*<summary>
    * Descripcion del atributo:  Se utiliza para aplicar f�sica a la bala y controlar su movimiento.
    </summary>
    */
    private Rigidbody2D Rigidbody2D;
    /*<summary>
    * Descripcion del atributo: Esta es una variable privada que almacena la direcci�n en la que la bala debe moverse
    </summary>
    */
    private Vector3 Direction;


    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyBullet", 2.0f);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemigo enemigo = other.GetComponent<Enemigo>();
        Player player = other.GetComponent<Player>();
        if (enemigo != null)
        {
            enemigo.Hit();
            DestroyBullet();
        }
        if (player != null && player.estaMuerto==false)
        {
            player.Hit();
            DestroyBullet();
        }
  
    }
}
