/*Fabian Esteban Lopez Arias 2216110
 * Carlos Andrés Garzón Guerrero 2220968
 * johann alberto Bocanegra 2200850
 * Nicolás Ramírez Arango 2195824
 */
//https://www.youtube.com/watch?v=uytdBD7xDrc Como hacer una BARRA de VIDA en Unity.
using UnityEngine.UI;
using UnityEngine;

/*
<summary>
Descripcion clase:Clase que gestiona la salud de un objeto en el juego y actualiza una barra de salud en la interfaz de usuario.
</summary>
*/
public class Health : MonoBehaviour
{
    /*
<summary>
Descripcion de atributos:Una referencia a una imagen (Image) que representa la barra de salud en la interfaz de usuario.
</summary>
*/
    public Image slideHealth;
    /*
<summary>
Descripcion de atributos:La salud actual del objeto.
</summary>
*/
    public float currentHealth;
    /*
<summary>
Descripcion de atributos:La salud máxima del objeto.
</summary>
*/
    public float maxHealth;
    /*
<summary>
Descripcion de atributos:Un booleano que indica si el objeto está muerto o no.
</summary>
*/
    public bool estaMuerto=false;
/*
<summary>
Descripcion de metodo:Método que se llama en cada fotograma y actualiza la barra
de salud en función de la salud actual y máxima del objeto.
</summary>
*/
    protected virtual void Update()
    {
 
        slideHealth.fillAmount = currentHealth / maxHealth;    
    }

}
