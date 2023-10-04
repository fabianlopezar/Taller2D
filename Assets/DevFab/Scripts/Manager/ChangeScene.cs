/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andr�s Garz�n Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicol�s Ram�rez Arango 2195824
 */
/*
    <summary>
        descripcion de la clase:permite cambiar entre escenas del juego utilizando funciones p�blicas para cargar escenas espec�ficas por nombre, y tambi�n se activa al colisionar con objetos que tengan etiquetas espec�ficas, lo que provoca la transici�n a escenas determinadas.
    </summary>
*/
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    /*<summary>
     * Descripcion del atributo: Se utiliza para declarar un nombrepara buscar en la escena.
     </summary>
     */
    public string sceneName;
    /*<summary>
     * Descripcion del metodo: Carga la escena con nombre "1" al ser llamado.
     </summary>
     */
    public void Scena1()
    {
        string nameScene = "1";
        SceneManager.LoadScene(nameScene);
    }
    /*<summary>
    * Descripcion del metodo: Carga la escena con nombre "2" al ser llamado.
    </summary>
    */
    public void Scena2()
    {
        string nameScene = "2";
        SceneManager.LoadScene(nameScene);
    }
    /*<summary>
    * Descripcion del metodo: Carga la escena con nombre "3" al ser llamado.
    </summary>
    */
    public void Scena3()
    {
        string nameScene = "3";
        SceneManager.LoadScene(nameScene);
    }
    /*<summary>
    * Descripcion del metodo: Carga la escena con nombre "Inicio" al ser llamado.
    </summary>
    */
    public void Inicial()
    {
        string nameScene = "Inicio";
        SceneManager.LoadScene(nameScene);
    }
    /*<summary>
   * Descripcion del metodo: Verifica las etiquetas de colisi�n y carga la escena correspondiente
   * ("Scena2()" o "Scena3()") cuando se colisiona con objetos etiquetados como "2" o "3".
   </summary>
   */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("2"))
        {
            Scena2();
        }
        if (other.CompareTag("3"))
        {
            Scena3();
        }
    }
}
