/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
/*
    <summary>
        descripcion de la clase:permite cambiar entre escenas del juego utilizando funciones públicas para cargar escenas específicas por nombre, y también se activa al colisionar con objetos que tengan etiquetas específicas, lo que provoca la transición a escenas determinadas.
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
    public void Scena1()
    {
        string nameScene = "1";
        SceneManager.LoadScene(nameScene);
    }
    public void Scena2()
    {
        string nameScene = "2";
        SceneManager.LoadScene(nameScene);
    }
    public void Scena3()
    {
        string nameScene = "3";
        SceneManager.LoadScene(nameScene);
    }
    
    public void Inicial()
    {
        string nameScene = "Inicio";
        SceneManager.LoadScene(nameScene);
    }
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
