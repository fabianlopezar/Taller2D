/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
using UnityEngine;

/* <summary>
 *  Descripcion de la clase: El código define un script que sigue al jugador en el juego, manteniendo la posición de la cámara centrada en el jugador en el plano X e Y. Si no se asigna un objeto Transform al atributo "player", se muestra un mensaje de error.s
  </summary>
*/

public class CameraScript : MonoBehaviour
{    /*<summary>
     * Descripcion del atributo: se utiliza para tener la referencia del player
     </summary>
     */
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            Vector3 position = transform.position;
            position.x = player.position.x;
            position.y = player.position.y;
            transform.position = position;
        }
        else
        {
            Debug.Log("Error en: `CameraScrtipt` deberia asignarle valor a la variable player.");
        }
    }
}
