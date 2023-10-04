/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;
/*
<summary>
Descripcion clase:Clase que define el comportamiento de recoger objetos en el juego.
</summary>
*/
public class PickUp : MonoBehaviour

{
    /*
    <summary>
    Descripcion de atributos:AudioClip que representa el sonido cuando se recoge un objeto.
    </summary>
    */
    public AudioClip coinSound;
    /*
<summary>
Descripcion de atributos: Referencia al componente AudioSource para reproducir sonidos.
</summary>
*/
    private AudioSource audioSource;
    /*
<summary>
Descripcion de metodo: Método de inicio que obtiene una referencia al componente AudioSource.
</summary>
*/
    private void Start()
    {
   
        audioSource = GetComponent<AudioSource>();
    }
    /*
<summary>
Descripcion de metodo: Método que se activa cuando el objeto entra en colisión con otro. Comprueba si el objeto colisionado tiene etiquetas específicas ("Gema1", "Gema2", "Gema3"),
y si es así, actualiza el juego y reproduce un sonido antes de destruir el objeto colisionado.
</summary>
*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema1"))
        {
            GameManager.Instance.AddGema("gema1");
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Gema2"))
        {
            GameManager.Instance.AddGema("gema2");
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Gema3"))
        {
            GameManager.Instance.AddGema("gema3");
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
       
    }
}
